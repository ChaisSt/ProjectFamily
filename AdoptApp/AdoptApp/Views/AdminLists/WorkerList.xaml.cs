using AdoptApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AdoptApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkerList : ContentPage
    {
        WorkerListVM vm;
        public WorkerList()
        {
            InitializeComponent();
            vm = new WorkerListVM();
            this.BindingContext = vm;
        }
        protected override void OnAppearing()
        {
            if (vm != null)
                vm.GetWorkers();

            base.OnAppearing();
        }
    }
}