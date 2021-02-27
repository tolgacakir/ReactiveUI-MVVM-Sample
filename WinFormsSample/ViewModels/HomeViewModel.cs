using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsSample.ViewModels
{
    public class HomeViewModel : ReactiveObject, IRoutableViewModel
    {
        private string _title;
        public string Title
        {
            get => _title;
            set => this.RaiseAndSetIfChanged(ref _title, value);
        }

        public string UrlPathSegment { get; protected set; }
        public IScreen HostScreen { get; protected set; }

        public HomeViewModel()
        {
            Title = "Home";
        }
    }
}
