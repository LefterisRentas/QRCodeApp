using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QRCodeApp.Core;
using QRCodeApp.Data;
using QRCodeApp.Services;
using QRCoder;

namespace QRCodeApp;

public static class MauiProgram
{
    private static readonly QRCodeGenerator QrCodeGenerator = new();

    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts => { fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular"); });

        builder.Services.AddMauiBlazorWebView();
        builder.Services.AddSingleton(QrCodeGenerator);
        builder.Services.AddLocalization();
        
        // Register SQLite DbContext
        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            // Path to SQLite database
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "qrcodes.db");
            options.UseSqlite($"Filename={dbPath}");
        });

        // Register the QRCode service
        builder.Services.AddScoped<QrCodeService>();
#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        // Use #if preprocessor directives to register platform-specific services
#if ANDROID
            builder.Services.AddSingleton<IFileSaver, QRCodeApp.Core.Android.FileSaver>();
#elif IOS
            builder.Services.AddSingleton<IFileSaver, QRCodeApp.Core.iOS.FileSaver>();
#elif WINDOWS
        builder.Services.AddSingleton<IFileSaver, QRCodeApp.Core.WinUI.FileSaver>();
#endif
        
        var app = builder.Build();
        // Apply migrations at app startup
        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            dbContext.Database.EnsureCreated(); // Creates the database if it doesn't exist
            dbContext.Database.Migrate(); // Automatically applies any pending migrations
        }
        
        return app;
    }
}