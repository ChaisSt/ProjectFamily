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
    public partial class AdminCaseList : ContentPage
    {
        AdminCaseListVM vm;   
        public AdminCaseList()
        {
            InitializeComponent();
            vm = new AdminCaseListVM();
            this.BindingContext = vm;
        }
        protected override void OnAppearing()
        {
            if (vm != null)
                vm.GetCases();

            base.OnAppearing();
        }
    }
}