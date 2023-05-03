using BootstrapBlazor.Components;
using MauiApp1.Data;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Globalization;
using System.Reflection;
using static Microsoft.Maui.Authentication.AppleSignInAuthenticator;

namespace MauiApp1;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<WeatherForecastService>();

        builder.Services.AddBootstrapBlazor(localizationConfigure: op =>
        {
            op.AdditionalJsonAssemblies = new Assembly[]
            {
                typeof(Main).Assembly,
            };
        });

        builder.Services.Configure<BootstrapBlazorOptions>(op =>
        {
            op.DefaultCultureInfo = "de";
            op.SupportedCultures = new List<string> { "de" };
        });

        var culture = new CultureInfo("de-DE");
        CultureInfo.DefaultThreadCurrentCulture = culture;
        CultureInfo.DefaultThreadCurrentUICulture = culture;

        return builder.Build();
    }
}
