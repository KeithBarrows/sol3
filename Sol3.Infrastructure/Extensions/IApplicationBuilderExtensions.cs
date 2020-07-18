using Microsoft.AspNetCore.Builder;
using Serilog;
using Sol3.Infrastructure.Logging;

namespace Sol3.Infrastructure.Extensions
{
    public static class IApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseSerilogRequestLoggingEnriched(this IApplicationBuilder app)
        {
            return app.UseSerilogRequestLogging(opts => opts.EnrichDiagnosticContext = LogHelper.EnrichFromRequest);
        }
    }
}
