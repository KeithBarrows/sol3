using Sol3.Infrastructure.Pattern;

namespace Sol3.Infrastructure.Configuration
{
    public class AppInfo : Singleton<AppInfo>
    {
        public string ContentRootPath { get; set; }

        public AppInfo() { }
    }
}
