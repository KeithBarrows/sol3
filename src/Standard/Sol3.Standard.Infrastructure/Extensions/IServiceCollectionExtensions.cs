//using Microsoft.AspNetCore.Mvc.Razor;
//using Microsoft.Extensions.DependencyInjection;
//using Sol3.Standard.Infrastructure.FeatureFolders;
//using Sol3.Standard.Infrastructure.Logging;

//namespace Sol3.Standard.Infrastructure.Extensions
//{
//    public static class IServiceCollectionExtensions
//    {
//        public static IServiceCollection ConfigureRazorViewLocationExpanders(this IServiceCollection services)
//        {
//            return services.Configure<RazorViewEngineOptions>(opts =>
//            {
//                opts.ViewLocationExpanders.Add(new FeatureLocationExpander());
//            });
//        }

//        public static IMvcBuilder AddControllersWithViewsAndLogging(this IServiceCollection services)
//        {
//            return services.AddControllersWithViews(opts =>
//            {
//                opts.Filters.Add<SerilogLoggingActionFilter>();
//            });
//        }
//    }
//}
