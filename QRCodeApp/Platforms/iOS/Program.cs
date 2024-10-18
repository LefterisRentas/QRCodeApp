using Foundation;
using ObjCRuntime;
using UIKit;
using QRCodeApp.Services;
using System.IO;

namespace QRCodeApp
{
    public class Program
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, typeof(AppDelegate));
        }
    }
}
namespace QRCodeApp.Core.iOS
{
    public class FileSaver : IFileSaver
    {
        public async Task SaveFileAsync(string filename, byte[] data)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var filePath = Path.Combine(documentsPath, filename);

            await File.WriteAllBytesAsync(filePath, data);

            // Use iOS's file sharing dialog to save the file to the device
            var url = NSUrl.FromFilename(filePath);
            var documentController = UIDocumentInteractionController.FromUrl(url);
            documentController.PresentPreview(true);
        }
    }
}