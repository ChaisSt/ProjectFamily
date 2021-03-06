using Android.Content;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;
using static AdoptApp.AppShell;

[assembly: Dependency(typeof(AdoptApp.Droid.CameraAndroid))]
namespace AdoptApp.Droid
{
    public class CameraAndroid : CameraInterface
	{
		public CameraAndroid()
		{
		}

        public Task<Stream> GetImageStreamAsync()
        {
            // Define the Intent for getting images
            Intent intent = new Intent();
            intent.SetType("image/*");
            intent.SetAction(Intent.ActionGetContent);

            // Start the picture-picker activity (resumes in MainActivity.cs)
            MainActivity.Instance.StartActivityForResult(
                Intent.CreateChooser(intent, "Select Picture"),
                MainActivity.PickImageId);

            // Save the TaskCompletionSource object as a MainActivity property
            MainActivity.Instance.PickImageTaskCompletionSource = new TaskCompletionSource<Stream>();

            // Return Task object
            return MainActivity.Instance.PickImageTaskCompletionSource.Task;
        }
    }
}