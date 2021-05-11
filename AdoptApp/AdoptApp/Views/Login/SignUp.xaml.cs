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
    public partial class SignUp : ContentPage
    {
        private RadioButton type = new RadioButton();

        public SignUp()
        {
            InitializeComponent();
            //this.NavigationPage.BarBackgroundColor = Color.FromHex("#6CAB63");
            this.BindingContext = new SignUpViewModel();
        }

        private void HandleChecked(object sender, EventArgs e)
        {
            var selection = sender as RadioButton;
            type = selection;
        }

        public void CreateAccount_Clicked(object sender, EventArgs e)
        {
            string v = type.Content.ToString();
            if (v == "View adoptable children")
            {
                Navigation.PushAsync(new NewFamily());
            }
            else
            {
                Navigation.PushAsync(new NewCaseWorker());
            }
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}