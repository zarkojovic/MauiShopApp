using CommunityToolkit.Maui;
using MauiIspitApp.Pages;
using MauiIspitApp.Services;
using MauiIspitApp.ViewModels;
using Microsoft.Extensions.Logging;

namespace MauiIspitApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("Ubuntu-Regular.ttf", "UbuntuRegular");
                fonts.AddFont("Ubuntu-Bold.ttf", "UbuntuBold");
            })
            .UseMauiCommunityToolkit();

        builder.Services.AddSingleton<CategoryService>();
        builder.Services.AddSingleton<HomePageViewModel>();
        builder.Services.AddSingleton<HomePage>();
        

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}