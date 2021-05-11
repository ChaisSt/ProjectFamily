using AdoptApp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static AdoptApp.AppShell;

namespace AdoptApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewFamily : ContentPage
    {
        public NewFamily()
        {
            try
            {
                InitializeComponent();
                this.BindingContext = new NewFamilyViewModel();
            }
            catch(Exception)
            {

            }
        }

        async void OnPickPhotoButtonClicked(object sender, EventArgs e)
        {
            (sender as Button).IsEnabled = false;
            Image image = new Image();

            Stream stream = await DependencyService.Get<CameraInterface>().GetImageStreamAsync();
            if (stream != null)
            {
                image.Source = ImageSource.FromStream(() => stream);
            }

            (sender as Button).IsEnabled = true;
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        public void CreateFamily(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewHome());
        }

        //private Picker interest = new Picker();
        private void AddInterest(object sender, EventArgs e)
        {
            //interest = sender as Picker;
        }
    }
}