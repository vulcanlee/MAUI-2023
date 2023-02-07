using AutoMapper;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAZ01.Dtos;
using MAZ01.Helpers;
using MAZ01.Models;
using MAZ01.Services;

namespace MAZ01.ViewModels;

public partial class SplashPageViewModel : ObservableObject, INavigatedAware
{
    #region Field Member
    private readonly INavigationService navigationService;
    private readonly JwtStoreService jwtStoreService;
    #endregion

    #region Property Member
    #endregion

    #region Constructor
    public SplashPageViewModel(INavigationService navigationService,
        JwtStoreService jwtStoreService)
    {
        this.navigationService = navigationService;
        this.jwtStoreService = jwtStoreService;
    }
    #endregion

    #region Method Member
    #region Command Method
    #endregion

    #region Navigation Event
    public void OnNavigatedFrom(INavigationParameters parameters)
    {
    }

    public async void OnNavigatedTo(INavigationParameters parameters)
    {
        await jwtStoreService.ReadAsync();
        await Task.Delay(2000);
        if (string.IsNullOrEmpty(jwtStoreService.JwtStore.LoginResponseDto.Token))
            await navigationService.NavigateAsync($"/{MagicValue.PageNameLogin}");
        else
            await navigationService.NavigateAsync($"/{MagicValue.PageNameHomePage}");
    }
    #endregion

    #region Other Method
    #endregion
    #endregion
}
