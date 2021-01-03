using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace eMusic.Mobile.Helpers
{
    public class ImageHelper
    {
        public static async Task<byte[]> UploadImage(byte[] image)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "This functionality is not supported on your device!", "OK");
                return image;
            }

            try
            {
                var mediaOptions = new PickMediaOptions()
                {
                    PhotoSize = PhotoSize.Medium
                };


                var selectedImageFile = await CrossMedia.Current.PickPhotoAsync(mediaOptions);

                if (selectedImageFile != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        var sourceStream = selectedImageFile.GetStream();
                        sourceStream.CopyTo(memoryStream);
                        return memoryStream.ToArray();
                    }
                }
            }
            catch
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Image could not be loaded!", "OK");
            }
            return image;
        }
    }
}
