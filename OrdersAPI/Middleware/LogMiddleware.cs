using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Newtonsoft.Json;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OrdersAPI.Middleware
{
    public class LogMiddleware
    {
        protected readonly RequestDelegate _next;
        protected static readonly ILogger Log = Serilog.Log.ForContext<LogMiddleware>();
        protected const string Template = "Http {RequestMethod} {RequestPath} responsed {StatusCode}";
        protected static readonly HashSet<string> HeaderList = new HashSet<string> { "Content-Length", "Content-Type" };

        public LogMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentException(nameof(next));
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext == null) throw new ArgumentException(nameof(httpContext));

            try
            {
                await _next(httpContext);

                var code = httpContext.Response?.StatusCode;
                var lvl = code > 499 ? LogEventLevel.Error : LogEventLevel.Information;

                var logger = lvl == LogEventLevel.Error ? LogErrorContext(httpContext) : Log;

                logger.Write(lvl, Template, httpContext.Request.Method, GetPath(httpContext), code);
            }
            catch (Exception ex) when (LoggerExpection(httpContext, ex))
            {
                var internalResponse = HttpStatusCode.InternalServerError;

                var result = JsonConvert.SerializeObject(new { error = ex.Message });
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = (int)internalResponse;
                await httpContext.Response.WriteAsync(result);
            }

        }

        static bool LoggerExpection(HttpContext httpContext, Exception ex)
        {
            LogErrorContext(httpContext).Error(ex, Template, httpContext.Request.Method, GetPath(httpContext), 500);

            return true;
        }

        static ILogger LogErrorContext(HttpContext httpContext)
        {
            var request = httpContext.Request;

            var headers = request.Headers.Where(x => HeaderList.Contains(x.Key)).ToDictionary(x => x.Key, x => x.Value.ToString());

            var result = Log.ForContext("RequestHeaders", headers, destructureObjects: true).ForContext("RequestHost", request.Host).ForContext("RequestProtocol", request.Protocol);

            return result;

        }

        static string GetPath(HttpContext httpContext)
        {
            return httpContext.Features.Get<IHttpRequestFeature>()?.RawTarget ?? httpContext.Request.Path.ToString();
        }
    }
}
