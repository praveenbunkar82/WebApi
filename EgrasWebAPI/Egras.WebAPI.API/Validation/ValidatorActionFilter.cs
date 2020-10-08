using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EgrasWebAPI.API
{
    /// <summary>
    /// Manage validations globlly by modelstate.valid 
    /// </summary>
    public class ValidatorActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filtercontext)
        {
            if (!filtercontext.ModelState.IsValid)
            {
                filtercontext.Result = new BadRequestObjectResult(filtercontext.ModelState);
            }
        }
        public void OnActionExecuted(ActionExecutedContext filtercontext) { }
    }
}
