using CommunityToolkit.Maui.Views;
using System.Diagnostics;

namespace CameraViewOrientationUpperRight
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            Camera.MediaCaptured += Camera_MediaCaptured;

            try
            {
                await Camera.StartCameraPreview(CancellationToken.None);
            }
            catch (Exception)
            {
                // Taking pictures always throws several Exceptions.
            }
        }

        private async void Camera_MediaCaptured(object? sender, MediaCapturedEventArgs e)
        {
            Stream imageStream = e.Media;

            byte[] img = new byte[imageStream.Length];
            await imageStream.ReadAsync(img.AsMemory(0, img.Length));

            string base64 = Convert.ToBase64String(img);
            Debug.WriteLine(base64);

            Photo.Source = ImageSource.FromStream(() =>
            {
                imageStream.Seek(0, SeekOrigin.Begin);
                return imageStream;
            });
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Camera.CaptureImage(CancellationToken.None);
        }
    }
}
