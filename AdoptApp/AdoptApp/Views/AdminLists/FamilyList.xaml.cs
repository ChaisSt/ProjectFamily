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
    public partial class FamilyList : ContentPage
    {
        FamilyListVM vm;
        public FamilyList()
        {
            InitializeComponent();
            vm = new FamilyListVM();
            this.BindingContext = vm;
        }
        protected override void OnAppearing()
        {
            if (vm != null)
                vm.GetFamilies();

            base.OnAppearing();
        }
    }
}