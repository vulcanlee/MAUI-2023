using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAZ01.Helpers;
using MAZ01.Services;

namespace MAZ01.ViewModels;

public partial class HomePageViewModel : ObservableObject, INavigatedAware
{
    #region Field Member
    private readonly INavigationService navigationService;
    private readonly UserService userService;
    #endregion

    #region Property Member
    #endregion

    #region Constructor
    public HomePageViewModel(INavigationService navigationService,
        UserService userService)
    {
        this.navigationService = navigationService;
        this.userService = userService;
    }
    #endregion

    #region Method Member
    #region Command Method
    [RelayCommand]
    async Task LogoutAsync()
    {
        userService.Logout();
        await navigationService.NavigateAsync($"/{MagicValue.PageNameLogin}");
    }
    #endregion

    #region Navigation Event
    public void OnNavigatedFrom(INavigationParameters parameters)
    {
    }

    public void OnNavigatedTo(INavigationParameters parameters)
    {
    }
    #endregion

    #region Other Method
    #endregion
    #endregion
}
