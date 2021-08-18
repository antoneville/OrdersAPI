using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace OrdersAPI.Controllers
{
    public class ControllerAPIBase : Controller
    {
        protected async Task<ActionResult<T>> ExecuteGet<T>(Func<Task<T>> function)
        {
            return Ok(await function());
        }

        protected async Task<ActionResult> ExecutePost(Func<Task> function)
        {
            await function();
            return Ok();
        }

        protected async Task<ActionResult> ExecutePut(Func<Task> function)
        {
            await function();
            return Ok();
        }
    }
}
