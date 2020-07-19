//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.FileProviders;
//using Microsoft.Extensions.Hosting;
//using Serilog;
//using Sol3.Standard.Infrastructure.Configuration;
//using Sol3.Standard.Infrastructure.Logging;

//namespace Sol3.Standard.Infrastructure.Extensions
//{
//    public static class StartupExtensions
//    {
//        /// <summary>
//        /// Wrapper to add into the Startup.cs file
//        /// </summary>
//        /// <param name="services"></param>
//        public static void InternalConfigureServices(IServiceCollection services) 
//        {
//            //services.AddControllersWithViews();
//            services.ConfigureRazorViewLocationExpanders()
//                    .AddControllersWithViewsAndLogging();
//        }

//        /// <summary>
//        /// Wrapper to add into the Startup.cs file
//        /// </summary>
//        /// <param name="services"></param>
//        public static void InternalConfigure(IApplicationBuilder app, IWebHostEnvironment env)
//        {
//            AppInfo.Instance.ContentRootPath = env.ContentRootPath;

//            if (env.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();
//            }
//            else
//            {
//                app.UseExceptionHandler("/Home/Error");
//                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//                app.UseHsts();
//            }

//            //app.UseHttpsRedirection();
//            app.UseStaticFiles();

//            app.UseFileServer(new FileServerOptions
//            {
//                FileProvider = new PhysicalFileProvider(@"E:\Gallery"),
//                RequestPath = new Microsoft.AspNetCore.Http.PathString("/Gallery"),
//                EnableDirectoryBrowsing = false
//            });

//            app.UseSerilogRequestLoggingEnriched();

//            app.UseRouting();

//            app.UseAuthorization();

//            app.UseEndpoints(endpoints =>
//            {
//                endpoints.MapControllerRoute(
//                    name: "default",
//                    pattern: "{controller=Home}/{action=Index}/{id?}");
//            });
//        }
//    }
//}
