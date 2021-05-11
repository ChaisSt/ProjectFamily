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
    public partial class LoginList : ContentPage
    {
        LoginListVM vm;
        public LoginList()
        {
            InitializeComponent();
            vm = new LoginListVM();
            this.BindingContext = vm;
        }

        protected override void OnAppearing()
        {
            if (vm != null)
                vm.GetLogins();

            base.OnAppearing();
        }
    }
}