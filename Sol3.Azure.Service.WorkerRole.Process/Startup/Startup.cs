using Owin;

namespace Sol3.Azure.Service.WorkerRole.Process.Startup
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            RegisterKatana(appBuilder);
        }
    }
}
