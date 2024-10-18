using Microsoft.EntityFrameworkCore;

namespace QRCodeApp.Data;

public class AppDbContext : DbContext
{
    public DbSet<QrCodeEntry> QrCodes { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}
