using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinFormsSample.ViewModels;

namespace WinFormsSample.Views
{
    public partial class HomeView : UserControl, IViewFor<HomeViewModel>
    {
        public HomeView()
        {
            InitializeComponent();

            this.WhenActivated(d =>
            {
                d(this.OneWayBind(ViewModel, vm => vm.Title, v => v.lblTitle.Text));
            });
        }

        public HomeViewModel ViewModel { get; set; }
        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (HomeViewModel)value;
        }
    }
}
