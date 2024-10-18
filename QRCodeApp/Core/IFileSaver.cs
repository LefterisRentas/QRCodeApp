namespace QRCodeApp.Core;

public interface IFileSaver
{
    Task SaveFileAsync(string filename, byte[] data);
}