using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using WinFormsSample.ViewModels;
using WinFormsSample.Views;

namespace WinFormsSample
{
    public class Bootstrapper
    {
        public Bootstrapper()
        {
            ConfigureServices();
        }
        private void ConfigureServices()
        {
            Locator.CurrentMutable.Register(() => new MainView(), typeof(IViewFor<MainViewModel>));
            Locator.CurrentMutable.Register(() => new HomeView(), typeof(IViewFor<HomeViewModel>));
            Locator.CurrentMutable.Register(() => new SettingsView(), typeof(IViewFor<SettingsViewModel>));
            Locator.CurrentMutable.Register(() => new DiagnosticsView(), typeof(IViewFor<DiagnosticsViewModel>));

        }
        public void Run()
        {
            var viewModel = new MainViewModel();
            Locator.CurrentMutable.RegisterConstant(viewModel, typeof(IScreen));
            var view = ViewLocator.Current.ResolveView(viewModel);
            view.ViewModel = viewModel;
            Application.Run((Form)view);
        }
    }
}
