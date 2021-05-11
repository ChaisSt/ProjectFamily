using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AdoptApp.ViewModels;
using AdoptApp.Views;
using Xamarin.Forms;

namespace AdoptApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(EmptyCase), typeof(EmptyCase));
        }

        public interface CameraInterface
        {
            Task<Stream> GetImageStreamAsync();
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
