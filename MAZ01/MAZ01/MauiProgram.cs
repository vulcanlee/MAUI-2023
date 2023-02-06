﻿using Prism.Ioc;
using MAZ01.ViewModels;
using MAZ01.Views;
using MAZ01.Services;
using MAZ01.Helpers;

namespace MAZ01;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UsePrism(prism =>
            {

                prism.RegisterTypes(container =>
                      {
                          container.RegisterForNavigation<MainPage, MainPageViewModel>();
                          container.RegisterForNavigation<SplashPage, SplashPageViewModel>();
                          container.RegisterForNavigation<LoginPage, LoginPageViewModel>();
                          container.RegisterForNavigation<HomePage, HomePageViewModel>();
                          container.RegisterForNavigation<ProductPage, ProductPageViewModel>();
                          container.RegisterForNavigation<ProductDetailPage, ProductDetailPageViewModel>();

                          container.Register<UserService>();
                      })
                     .OnInitialized(() =>
                      {
                          // Do some initializations here
                      })
                     .OnAppStart(async navigationService =>
                     {
                         // Navigate to First page of this App
                         var result = await navigationService
                         .NavigateAsync($"/{MagicValue.PageNameSplash}");
                         if (!result.Success)
                         {
                             System.Diagnostics.Debugger.Break();
                         }
                     });
            })
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        return builder.Build();
    }
}
