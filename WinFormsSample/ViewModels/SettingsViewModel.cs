using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsSample.ViewModels
{
    public class SettingsViewModel : ReactiveObject, IRoutableViewModel
    {
        private string _title;
        public string Title
        {
            get => _title;
            set => this.RaiseAndSetIfChanged(ref _title, value);
        }

        public string UrlPathSegment { get; protected set; }
        public IScreen HostScreen { get; protected set; }

        private string _permanentState;
        public string PermanentState
        {
            get => _permanentState;
            set => this.RaiseAndSetIfChanged(ref _permanentState, value);
        }


        public SettingsViewModel()
        {
            Title = "Settings";
        }
    }
}
