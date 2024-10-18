using Microsoft.UI.Xaml;
using Windows.Storage;
using Windows.Storage.Pickers;
using QRCodeApp.Services;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using WinRT.Interop;

namespace QRCodeApp.Core.WinUI
{
    public class FileSaver : IFileSaver
    {
        public async Task SaveFileAsync(string filename, byte[] data)
        {
            // Use FileSavePicker to allow the user to pick the location to save the file
            var savePicker = new FileSavePicker();

            // Retrieve the current window handle
            var hwnd = GetWindowHandle();

            // Initialize the FileSavePicker and associate it with the window
            InitializeWithWindow.Initialize(savePicker, hwnd);

            savePicker.SuggestedStartLocation = PickerLocationId.Downloads;
            savePicker.SuggestedFileName = filename;

            // Set file types you want to allow
            savePicker.FileTypeChoices.Add("PNG File", new List<string> { ".png" });

            StorageFile file = await savePicker.PickSaveFileAsync();

            if (file != null)
            {
                // Write the data to the file
                await FileIO.WriteBytesAsync(file, data);
            }
        }

        private IntPtr GetWindowHandle()
        {
            // Retrieve the window handle for the current MAUI window
            var window = ((MauiWinUIWindow)Microsoft.Maui.Controls.Application.Current.Windows[0].Handler.PlatformView);
            var windowHandle = WindowNative.GetWindowHandle(window);
            return windowHandle;
        }
    }
}