using Sol3.Standard.Infrastructure.Pattern.Creational;

namespace Sol3.Core.Infrastructure.Configuration
{
    public class AppInfo : Singleton<AppInfo>
    {
        public string ContentRootPath { get; set; }

        public AppInfo() { }
    }
}
