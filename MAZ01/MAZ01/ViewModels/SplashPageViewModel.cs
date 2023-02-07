using AutoMapper;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAZ01.Dtos;
using MAZ01.Helpers;
using MAZ01.Models;

namespace MAZ01.ViewModels;

public partial class SplashPageViewModel : ObservableObject, INavigatedAware
{
    #region Field Member
    private readonly INavigationService navigationService;
    #endregion

    #region Property Member
    #endregion

    #region Constructor
    public SplashPageViewModel(INavigationService navigationService)
    {
        this.navigationService = navigationService;
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
        await Task.Delay(2000);
        await navigationService.NavigateAsync($"/{MagicValue.PageNameLogin}");
    }
    #endregion

    #region Other Method
    #endregion
    #endregion
}
