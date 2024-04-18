using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Host_Service.ActionFilters
{
    public class ValidationFilterAttribute : IActionFilter
    {
        public ValidationFilterAttribute()
        {
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            var action = context.RouteData.Values["action"];
            var controller = context.RouteData.Values["controller"];

            var param = context.ActionDescriptor.Parameters.SingleOrDefault(p => p.Name.Contains("Dto"));

            if (param is null)
            {

                context.Result = new BadRequestObjectResult($"{param} object is null. Controller: {controller} Action{action}");

                return;
            }

            if (!context.ModelState.IsValid)
                context.Result = new UnprocessableEntityObjectResult(context.ModelState);

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
