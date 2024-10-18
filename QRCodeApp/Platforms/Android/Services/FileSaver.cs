using Android.Content;
using Android.Provider;
using Android.App;
using Android.OS;
using Application = Android.App.Application;
using Java.IO;
using Uri = Android.Net.Uri;
using System.IO;
using QRCodeApp.Services;
using AndroidEnvironment = Android.OS.Environment;

namespace QRCodeApp.Core.Android
{
    public class FileSaver : IFileSaver
    {
        public async Task SaveFileAsync(string fileName, byte[] data)
        {
            // Use MediaStore to save the file in the Downloads directory
            var contentResolver = Application.Context.ContentResolver;
            var contentValues = new ContentValues();
            contentValues.Put(MediaStore.IMediaColumns.DisplayName, fileName);
            contentValues.Put(MediaStore.IMediaColumns.MimeType, "application/octet-stream");
            contentValues.Put(MediaStore.IMediaColumns.RelativePath, AndroidEnvironment.DirectoryDownloads);

            var uri = contentResolver.Insert(MediaStore.Downloads.ExternalContentUri, contentValues);

            if (uri != null)
            {
                using (var outputStream = contentResolver.OpenOutputStream(uri))
                {
                    if (outputStream != null)
                    {
                        await outputStream.WriteAsync(data, 0, data.Length);
                    }
                }

                // Create an intent to view the file
                var intent = new Intent(Intent.ActionView);
                intent.SetDataAndType(uri, "application/octet-stream");
                intent.AddFlags(ActivityFlags.NewTask | ActivityFlags.GrantReadUriPermission);

                // Start the activity with the intent
                Application.Context.StartActivity(intent);
            }
        }
    }
}