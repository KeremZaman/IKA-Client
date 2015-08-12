using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using Ninject;
using Ninject.Extensions.Conventions;
using IKA.ViewModels;
namespace IKA
{
    public class AppBootstrapper : BootstrapperBase
    {
        string path = Path.Combine(Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath));
        private IDictionary<string, Type> _viewModelDictionary;
        private IKernel _kernel;
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
           DisplayRootViewFor<MainViewModel>();
        }

        private void RegisterViewModel<T>(string key)
        {
            if (_viewModelDictionary.ContainsKey(key))
                _viewModelDictionary[key] = typeof(T);
            else
            {
                _viewModelDictionary.Add(key, typeof(T));
            }
        }
        protected override void Configure()
        {
            _viewModelDictionary = new Dictionary<string, Type>();

            _kernel = new StandardKernel();
            _kernel.Bind<IWindowManager>().To<WindowManager>().InSingletonScope();
            _kernel.Bind<IEventAggregator>().To<EventAggregator>().InSingletonScope();
            RegisterViewModel<HeadlightViewModel>("FarKornaViewModel");
            RegisterViewModel<MainViewModel>("MainViewModel");
            _kernel.Load(Assembly.GetExecutingAssembly());
            _kernel.Bind(x => x
        .From(GetType().Assembly)
        .SelectAllClasses().InNamespaceOf(GetType())
        .BindAllInterfaces()
        .Configure(b => b.InSingletonScope()));
          /*  _kernel.Bind(y => y
                .From(GetType().Assembly)
                .SelectAllClasses().Where(a => a.Name.EndsWith("ViewModel"))
                .BindDefaultInterfaces()
                .Configure(b => b.InTransientScope())
                );*/
            /*_kernel.Bind(x => x.FromAssemblyContaining<ControlFromSocket>()
                .SelectAllClasses()
                .BindDefaultInterfaces().Configure(y => y.InSingletonScope()));*/
        }
        /*
         * I am using Ninject as a ioc container, I am appliying auto-wiring and getting assemblies so: 
 _kernel.Bind(x => x.FromAssemblyContaining<ControlFromSocket>() 

 It is not an effective method and it can't bind some interfaces. How can I get all assemblies in Project?
         */
        protected override object GetInstance(Type service, string key)
        {

            return string.IsNullOrEmpty(key) ? _kernel.Get(service) : _kernel.Get(service, key);

        }



        protected override IEnumerable<object> GetAllInstances(Type service)
        {

            return _kernel.GetAll(service);

        }



        protected override void BuildUp(object instance)
        {

            _kernel.Inject(instance);

        }



        protected override void OnExit(object sender, EventArgs e)
        {

            _kernel.Dispose();

        }



    }

}
