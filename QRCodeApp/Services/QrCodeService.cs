using Microsoft.EntityFrameworkCore;
using QRCodeApp.Data;

namespace QRCodeApp.Services;

public class QrCodeService
{
    private readonly AppDbContext _dbContext;

    public QrCodeService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // Save or update QR code entry
    public async Task SaveOrUpdateQrCodeAsync(QrCodeEntry qrCodeEntry)
    {
        var existingQrCode = await _dbContext.QrCodes
            .FirstOrDefaultAsync(q => q.Name == qrCodeEntry.Name);

        if (existingQrCode == null)
        {
            // Add new QR code entry
            await _dbContext.QrCodes.AddAsync(qrCodeEntry);
        }
        else
        {
            // Update existing QR code entry
            existingQrCode.Value = qrCodeEntry.Value;
            existingQrCode.QrCodeBase64 = qrCodeEntry.QrCodeBase64;
            _dbContext.QrCodes.Update(existingQrCode);
        }

        await _dbContext.SaveChangesAsync();
    }

    // Get QR code by name
    public async Task<QrCodeEntry?> GetQrCodeByNameAsync(string name)
    {
        return await _dbContext.QrCodes.FirstOrDefaultAsync(q => q.Name == name);
    }

    // List all QR codes
    public async Task<List<QrCodeEntry>> GetAllQrCodesAsync()
    {
        return await _dbContext.QrCodes.ToListAsync();
    }
    
    // Delete QR code by name
    public async Task DeleteQrCodeByNameAsync(string name)
    {
        var qrCode = await _dbContext.QrCodes.FirstOrDefaultAsync(q => q.Name == name);
        if (qrCode != null)
        {
            _dbContext.QrCodes.Remove(qrCode);
            await _dbContext.SaveChangesAsync();
        }
    }
}
