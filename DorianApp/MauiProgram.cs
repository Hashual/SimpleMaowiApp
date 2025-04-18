using Microsoft.Extensions.Logging;
using DorianApp.Views;
using DorianApp.ViewModels;
using DorianApp.Services;
using DorianApp.Models;

namespace DorianApp;

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
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // Enregistrement des pages pour la navigation Shell
        builder.Services.AddTransient<HomePage>();
        builder.Services.AddTransient<InfoPage>();
        builder.Services.AddTransient<AddPage>();
        builder.Services.AddTransient<SearchPage>();
        builder.Services.AddTransient<GifPage>();

        // Enregistrement des ViewModels
        builder.Services.AddTransient<HomePageViewModel>();
        builder.Services.AddTransient<GifPageViewModel>();

        // Enregistrement des services
        builder.Services.AddSingleton<TrefleApiService>();
        builder.Services.AddTransient<Plant>();


#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}