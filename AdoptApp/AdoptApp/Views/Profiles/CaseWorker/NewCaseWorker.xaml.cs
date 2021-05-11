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
    public partial class NewCaseWorker : ContentPage
    {
        public NewCaseWorker()
        {
            try
            {
                InitializeComponent();
                this.BindingContext = new NewCaseWorkerViewModel();

            }
            catch (Exception)
            {

            }
        }

        public void CreateWorker(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}