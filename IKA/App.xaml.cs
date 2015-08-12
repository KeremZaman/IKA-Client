using System.Windows;

namespace IKA
{
    public partial class App : Application
    {
        public App()
        {
            AppBootstrapper bootstrapper = new AppBootstrapper();
            bootstrapper.Initialize();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
        }
    }
}
