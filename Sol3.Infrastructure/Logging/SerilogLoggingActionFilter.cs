using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;

/*
 * Read this to understand how to suppoer ASP.NET Core 3.x in a Class file...
 * https://docs.microsoft.com/en-us/aspnet/core/fundamentals/target-aspnetcore?view=aspnetcore-3.1&tabs=visual-studio
 * 
 * Thanks to Andrew Lock for the inspiration and some of the code...
 * https://github.com/andrewlock/blog-examples/tree/master/SerilogRequestLogging
 * 
 */

namespace Sol3.Infrastructure.Logging
{
    public class SerilogLoggingActionFilter : IActionFilter
    {
        private readonly IDiagnosticContext _diagnosticContext;
        public SerilogLoggingActionFilter(IDiagnosticContext diagnosticContext)
        {
            _diagnosticContext = diagnosticContext;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _diagnosticContext.Set("RouteData", context.ActionDescriptor.RouteValues);
            _diagnosticContext.Set("ActionName", context.ActionDescriptor.DisplayName);
            _diagnosticContext.Set("ActionId", context.ActionDescriptor.Id);
            _diagnosticContext.Set("ValidationState", context.ModelState.IsValid);
        }

        // Required by the interface
        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
