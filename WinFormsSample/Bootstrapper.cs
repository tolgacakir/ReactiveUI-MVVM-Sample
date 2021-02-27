using Autofac;
using ReactiveUI;
using Splat;
using System.Windows.Forms;
using WinFormsSample.ViewModels;
using WinFormsSample.Views;
using Splat.Autofac;

namespace WinFormsSample
{
    public class Bootstrapper
    {
        private readonly IContainer _container;

        public Bootstrapper()
        {
            _container = ConfigureServices();

            var autofacResolver = _container.Resolve<AutofacDependencyResolver>();
            autofacResolver.SetLifetimeScope(_container);
        }

        private IContainer ConfigureServices()
        {
            var builder = new ContainerBuilder();

            builder.Register(c => new MainView())
                .As<IViewFor<MainViewModel>>()
                .SingleInstance();
            builder.Register(c => new MainViewModel(_container))
                .As<IScreen>()
                .SingleInstance();

            builder.Register(c => new HomeView())
                .As<IViewFor<HomeViewModel>>();
            builder.Register(c => new DiagnosticsView())
                .As<IViewFor<DiagnosticsViewModel>>();
            builder.Register(c => new SettingsView())
                .As<IViewFor<SettingsViewModel>>();

            builder.Register(c => new HomeViewModel())
                .As<HomeViewModel>()
                .SingleInstance();
            builder.Register(c => new SettingsViewModel())
                .As<SettingsViewModel>()
                .SingleInstance();
            builder.Register(c => new DiagnosticsViewModel())
                .As<DiagnosticsViewModel>()
                .SingleInstance();

            var autofacResolver = builder.UseAutofacDependencyResolver();
            builder.RegisterInstance(autofacResolver);
            autofacResolver.InitializeReactiveUI();

            return builder.Build();
        }

        public void Run()
        {
            var view = _container.Resolve<IViewFor<MainViewModel>>();
            var viewModel = _container.Resolve<IScreen>();
            view.ViewModel = (MainViewModel)viewModel;
            Application.Run((Form)view);
        }
    }
}
