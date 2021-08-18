using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OrdersAPI.Business.Profiles;
using OrdersAPI.Business.Validators;
using OrdersAPI.Middleware;

namespace OrdersAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Infrastructure.ConfigureServices.Configure(services, Configuration);
            services.AddAutoMapper(typeof(OrderServiceProfile));
            services.AddAutoMapper(typeof(OrderDetailServiceProfile));
            services.AddAutoMapper(typeof(ProductServiceProfile));
            services.AddAutoMapper(typeof(DeliveryAddressServiceProfile));


            services.AddMvc(options => options.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Latest)
                .AddFluentValidation(r => r.RegisterValidatorsFromAssemblyContaining<DeliveryAddressValidator>());

            
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "OrdersAPI", Version = "v1" });
            });

            services.AddOptions();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "OrdersAPI");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
                app.UseMiddleware(typeof(LogMiddleware));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
        }
    }
}
