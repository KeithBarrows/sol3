//using Microsoft.Extensions.DependencyInjection;
//using Sol3.Framework.Infrastructure.Web.Razor;

//namespace Sol3.Framework.Infrastructure.Web.Startup
//{
//    public static class ServiceCollection
//    {
//        public static IServiceCollection AddMvcAndFeatureFolders(this IServiceCollection services)
//        {
//            services.AddMvc(o => o.Conventions.Add(new FeatureConvention()))
//                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
//                .AddRazorOptions(options =>
//                {
//                    // {0} - Action Name
//                    // {1} - Controller Name
//                    // {2} - Feature Name
//                    // Replace normal view location entirely
//                    options.ViewLocationFormats.Clear();
//                    options.ViewLocationFormats.Add("/Features/{2}/{1}/{0}.cshtml");
//                    options.ViewLocationFormats.Add("/Features/{2}/{0}.cshtml");
//                    options.ViewLocationFormats.Add("/Features/Shared/{0}.cshtml");
//                    options.ViewLocationExpanders.Add(new FeatureFoldersRazorViewEngine());
//                });
//            //services = services.Configure<RazorViewEngineOptions>(options =>
//            //{
//            //    options.ViewLocationExpanders.Add(new FeatureLocationExpander());
//            //});

//            return services;
//        }
//    }
//}
