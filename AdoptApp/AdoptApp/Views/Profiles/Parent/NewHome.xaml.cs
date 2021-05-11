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
    public partial class NewHome : ContentPage
    {
        public NewHome()
        {
            try
            {
                InitializeComponent();
                this.BindingContext = new NewHomeViewModel();

            }
            catch (Exception)
            {

            }
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void CreateHome(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }
    }
}
