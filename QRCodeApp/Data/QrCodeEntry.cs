using System.ComponentModel.DataAnnotations;

namespace QRCodeApp.Data;

public class QrCodeEntry
{
    public int Id { get; set; }
    
    // The name associated with this QR code
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    // The value that generates the QR code
    [MaxLength(7089)]
    public string Value { get; set; } = string.Empty;
    
    // Optional: Store the base64 image of the QR code to avoid re-generating it each time
    // ReSharper disable once EntityFramework.ModelValidation.UnlimitedStringLength
    public string QrCodeBase64 { get; set; } = string.Empty;
}
