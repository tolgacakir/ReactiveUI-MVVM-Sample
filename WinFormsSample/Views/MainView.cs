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
    public partial class MainView : Form, IViewFor<MainViewModel>
    {
        public MainView()
        {
            InitializeComponent();
            this.WhenActivated(d =>
            {
                d(this.OneWayBind(ViewModel, vm => vm.Router, v => v.routedControlHost1.Router));
                d(this.OneWayBind(ViewModel, vm => vm.Title, v => v.lblTitle.Text));
                d(this.BindCommand(ViewModel, vm => vm.ShowHomeCommand, v => v.btnHome));
                d(this.BindCommand(ViewModel, vm => vm.ShowDiagnosticsCommand, v => v.btnDiagnostics));
                d(this.BindCommand(ViewModel, vm => vm.ShowSettingsCommand, v => v.btnSettings));
                d(this.BindCommand(ViewModel, vm => vm.GoBackCommand, v => v.btnBack));

            });
        }

        public MainViewModel ViewModel { get; set; }
        object IViewFor.ViewModel 
        {
            get => ViewModel;
            set => ViewModel = (MainViewModel)value;
        }
    }
}
