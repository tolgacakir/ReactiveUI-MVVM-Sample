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
    public partial class DiagnosticsView : UserControl, IViewFor<DiagnosticsViewModel>
    {
        public DiagnosticsView()
        {
            InitializeComponent();

            this.WhenActivated(d =>
            {
                d(this.OneWayBind(ViewModel, vm => vm.Title, v => v.lblTitle.Text));
            });
        }

        public DiagnosticsViewModel ViewModel { get; set; }
        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (DiagnosticsViewModel)value;
        }
    }
}
