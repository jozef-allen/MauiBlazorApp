using Microsoft.AspNetCore.Components.WebView.Maui;
using MauiBlazorApp.Data;
using MauiBlazorApp.Services;
using MauiBlazorApp.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MauiBlazorApp
{
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
#endif

            builder.Services.AddSingleton<WeatherForecastService>();

            builder.Services.AddTransient<IMyApiService, MyApiService>();
            builder.Services.AddHttpClient<IMyApiService, MyApiService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:your_api_port/");
            });

            return builder.Build();
        }
    }
}
