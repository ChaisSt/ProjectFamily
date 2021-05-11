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
    public partial class NewCase : ContentPage
    {
        public NewCase()
        {
            try
            {
                InitializeComponent();
                NewCaseViewModel vm = new NewCaseViewModel();
                this.BindingContext = vm;
            }
            catch (Exception)
            {

            }
        }

        async void OnPickPhotoButtonClicked(object sender, EventArgs e)
        {
            (sender as Button).IsEnabled = false;
            Xamarin.Forms.Image image = new Image();

            Stream stream = await DependencyService.Get<CameraInterface>().GetImageStreamAsync();
            if (stream != null)
            {
                image.Source = ImageSource.FromStream(() => stream);
                if (image.Source is Xamarin.Forms.StreamImageSource)
                {
                    Xamarin.Forms.StreamImageSource objFileImageSource = (Xamarin.Forms.StreamImageSource)image.Source;
                    //
                    // Access the file that was specified:-
                    string strFileName = objFileImageSource.ToString();
                }
            }

            (sender as Button).IsEnabled = true;
        }
        private void ImageButton_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }

        public void CreateCase(object sender, EventArgs e)
        {
            Routing.RegisterRoute(nameof(WorkerNav), typeof(WorkerNav));
            Shell.Current.GoToAsync(nameof(WorkerNav));
        }
    }
}