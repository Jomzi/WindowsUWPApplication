using CalorieCount.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Imaging;
using Windows.Media.Capture;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CalorieCount.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            this.InitializeComponent();

            getSettings();
            loadProfilePhoto();
        }

        Settings appSettings = new Settings();
        private int clicked = 1;

        public object HardcodedValues { get; private set; }

        /* Start of Settings Functions ====================================================================================== */
        /* Save user settings to a file | Create that file if it doesn't exist */
        private async void setSettings(Settings settings)
        {
            try
            {
                var mySettings = await MainPage.getStorageFolder().GetFileAsync("mySettingsTest.txt");

                await FileIO.WriteTextAsync(mySettings, settings.ToString());
            }
            catch
            {
                var mySettings = await MainPage.getStorageFolder().CreateFileAsync("mySettingsTest.txt");

                await FileIO.WriteTextAsync(mySettings, settings.ToString());
            }
        }

        /* Load user settings from a file and use a buffer for loop to strip data | Do nothing if file does not exist */
        private async void getSettings()
        {
            try
            {
                var mySettings = await MainPage.getStorageFolder().GetFileAsync("mySettingsTest.txt");
                var buffer = await FileIO.ReadLinesAsync(mySettings);

                appSettings.name = buffer[0];
                appSettings.age = int.Parse(buffer[1]);

                loadSettings();
            }
            catch (Exception e)
            {

            }
        }

        /* Set view components to display user settings */
        private void loadSettings()
        {
            NameTB.Text = appSettings.name;
            AgeTB.Text = appSettings.age.ToString();
        }
        /* End of Settings Functions ====================================================================================== */


        /* Start of Profile Photo Functions ====================================================================================== */

        /* Use UWP CaptureUI to use the camera to take a picture, copy that picture to a storage file and delete the picture */
        private async void takePhoto()
        {
            CameraCaptureUI captureUI = new CameraCaptureUI();
            captureUI.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;
            captureUI.PhotoSettings.CroppedSizeInPixels = new Size(200, 200);

            StorageFile photo = await captureUI.CaptureFileAsync(CameraCaptureUIMode.Photo);

            if (photo == null)
            {
                // User cancelled photo capture
                return;
            }

            await photo.CopyAsync(MainPage.getStorageFolder(), "ProfilePictureTest.jpg", NameCollisionOption.ReplaceExisting);
            await photo.DeleteAsync();

            loadProfilePhoto();
        }

        /* Open up the photo file using a stream and bitmap decoder, parse it through an RGB loader and use the parsed bitmap as the profile picture in the view */
        private async void loadProfilePhoto()
        {
            try
            {
                var photo = await MainPage.getStorageFolder().GetFileAsync("ProfilePictureTest.jpg");

                IRandomAccessStream stream = await photo.OpenAsync(FileAccessMode.Read);
                BitmapDecoder decoder = await BitmapDecoder.CreateAsync(stream);
                SoftwareBitmap softwareBitmap = await decoder.GetSoftwareBitmapAsync();

                SoftwareBitmap softwareBitmapBGR8 = SoftwareBitmap.Convert(softwareBitmap, BitmapPixelFormat.Bgra8, BitmapAlphaMode.Premultiplied);

                SoftwareBitmapSource bitmapSource = new SoftwareBitmapSource();
                await bitmapSource.SetBitmapAsync(softwareBitmapBGR8);

                imageControl.Source = bitmapSource;

            }
            catch
            {
                BitmapImage image = new BitmapImage(new Uri("ms-appx:///Assets/nophoto.jpg"));
                imageControl.Source = image;
            }
        }

        /* Open up a HttpClient and use the url parameter to pass in a string, follow the strings url and download image. */
        public async void downLoadImage(string url)
        {
            try
            {
                var coverpic_file = await MainPage.getStorageFolder().CreateFileAsync("ProfilePictureTest.jpg");

                try
                {
                    HttpClient client = new HttpClient(); // Create HttpClient
                    byte[] buffer = await client.GetByteArrayAsync(url); // Download file
                    using (Stream stream = await coverpic_file.OpenStreamForWriteAsync())
                        stream.Write(buffer, 0, buffer.Length); // Save

                    loadProfilePhoto();
                }
                catch
                {
                    var Dialog = new MessageDialog("")
                    {
                        Title = "Error",
                        Content = "There was an error uploading your image. Please check the link and ensure it's the image's url and not a url to the website."

                    };
                    await Dialog.ShowAsync();

                    return;
                }
            }
            catch
            {
                var coverpic_file = await MainPage.getStorageFolder().GetFileAsync("ProfilePictureTest.jpg");

                try
                {
                    HttpClient client = new HttpClient(); // Create HttpClient
                    byte[] buffer = await client.GetByteArrayAsync(url); // Download file
                    using (Stream stream = await coverpic_file.OpenStreamForWriteAsync())
                        stream.Write(buffer, 0, buffer.Length); // Save

                    loadProfilePhoto();
                }
                catch
                {
                    var Dialog = new MessageDialog("")
                    {
                        Title = "Error",
                        Content = "There was an error uploading your image. Please check the link and ensure it's the image's url and not a url to the website."

                    };
                    await Dialog.ShowAsync();

                    return;
                }
            }
        }
        /* End of Profile Photo Functions ====================================================================================== */

        /* Start of Button Events ====================================================================================== */

        private void SaveButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                appSettings.name = NameTB.Text;
                appSettings.age = int.Parse(AgeTB.Text);
                setSettings(appSettings);
                ErrorTB.Visibility = Visibility.Collapsed;
            }
            catch
            {
                ErrorTB.Text = "Please enter a valid numeric value for Age.";
                ErrorTB.Visibility = Visibility.Visible;
            }
        }

        private void CancelButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void imageControl_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if(clicked % 2 == 0)
            {
                newPhotoRP.Visibility = Visibility.Collapsed;
            }
            else
            {
                newPhotoRP.Visibility = Visibility.Visible;
            }

            clicked++;

        }

        private void takePicture_Tapped(object sender, TappedRoutedEventArgs e)
        {
            takePhoto();
        }


        private void uploadPicture_Tapped(object sender, TappedRoutedEventArgs e)
        {
            newPhotoRP.Height = 100;
            imageUrl.Visibility = Visibility.Visible;
            uploadPicture.Visibility = Visibility.Collapsed;
            takePicture.Visibility = Visibility.Collapsed;
            saveInternet.Visibility = Visibility.Visible;
            cancelInternet.Visibility = Visibility.Visible;
        }

        private void saveInternet_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                downLoadImage(imageUrl.Text);
            }
            catch
            {
                imageUrl.Text = null;
            }
        }

        private void cancelInternet_Tapped(object sender, TappedRoutedEventArgs e)
        {
            newPhotoRP.Height = 60;
            imageUrl.Visibility = Visibility.Collapsed;
            uploadPicture.Visibility = Visibility.Visible;
            takePicture.Visibility = Visibility.Visible;
            saveInternet.Visibility = Visibility.Collapsed;
            cancelInternet.Visibility = Visibility.Collapsed;
        }
        /* End of Button Events ====================================================================================== */

    }
}
