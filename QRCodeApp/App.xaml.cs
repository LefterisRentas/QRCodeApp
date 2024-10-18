using System.Globalization;

namespace QRCodeApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        CultureInfo.CurrentCulture = new CultureInfo(Preferences.Get("language", "en-US"));
        SetCulture(CultureInfo.CurrentCulture);
        MainPage = new MainPage();
    }

    private void SetCulture(CultureInfo currentCulture)
    {
        CultureInfo.DefaultThreadCurrentCulture = currentCulture;
        CultureInfo.DefaultThreadCurrentUICulture = currentCulture;
    }
}