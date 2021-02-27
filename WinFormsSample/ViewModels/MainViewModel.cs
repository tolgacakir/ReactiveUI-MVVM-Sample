using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormsSample.ViewModels
{
    public class MainViewModel : ReactiveObject, IScreen
    {
        private string _title;
        public string Title
        { 
            get => _title;
            set => this.RaiseAndSetIfChanged(ref _title, value);
        }

        private bool _backCanExecute;
        public bool BackCanExecute
        {
            get => _backCanExecute;
            set => this.RaiseAndSetIfChanged(ref _backCanExecute, value);
        }

        private IRoutableViewModel _currentViewModel;
        public IRoutableViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set => this.RaiseAndSetIfChanged(ref _currentViewModel, value);
        }

        public RoutingState Router { get; }
        public ReactiveCommand<Unit,Unit> ShowHomeCommand { get; }
        public ReactiveCommand<Unit,Unit> ShowSettingsCommand { get; }
        public ReactiveCommand<Unit, Unit> ShowDiagnosticsCommand { get; }
        public ReactiveCommand<Unit,Unit> GoBackCommand { get; }
        public MainViewModel()
        {
            Router = new RoutingState();
            Title = "Title";
            ShowHomeCommand = ReactiveCommand.Create(ShowHome,
                this.WhenAnyValue(vm=>vm.CurrentViewModel).Select(t=>t?.GetType() != typeof(HomeViewModel)));
            ShowSettingsCommand = ReactiveCommand.Create(ShowSettings,
                this.WhenAnyValue(vm => vm.CurrentViewModel).Select(t => t?.GetType() != typeof(SettingsViewModel)));
            ShowDiagnosticsCommand = ReactiveCommand.Create(ShowDiagnostics,
                this.WhenAnyValue(vm => vm.CurrentViewModel).Select(t => t?.GetType() != typeof(DiagnosticsViewModel)));

            GoBackCommand = ReactiveCommand.Create(GoBack,
                this.WhenAnyValue(vm => vm.CurrentViewModel).Select(t => t?.GetType() != typeof(HomeViewModel)));


            ShowHome();
        }

        private void ShowView(IRoutableViewModel viewModel)
        {
            Router
                .Navigate
                .Execute(viewModel)
                .Subscribe();
            CurrentViewModel = Router.NavigationStack[Router.NavigationStack.Count - 1];
        }
        private void ShowHome()
        {
            ShowView(new HomeViewModel());
        }
        private void ShowSettings()
        {
            ShowView(new SettingsViewModel());
        }
        private void ShowDiagnostics()
        {
            ShowView(new DiagnosticsViewModel());
        }
        private void GoBack()
        {
            if (Router.NavigationStack.Count>0)
            {
                Router
                    .NavigateBack
                    .Execute()
                    .Subscribe();
                CurrentViewModel = Router.NavigationStack[Router.NavigationStack.Count - 1];
            }
        }
    }
}
