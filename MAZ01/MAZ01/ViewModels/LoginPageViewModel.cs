using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAZ01.Services;

namespace MAZ01.ViewModels;

public partial class LoginPageViewModel : ObservableObject, INavigatedAware
{
    #region Field Member
    private readonly INavigationService navigationService;
    private readonly UserService userService;
    #endregion

    #region Property Member
    [ObservableProperty]
    string account = string.Empty;
    [ObservableProperty]
    string password = string.Empty;
    [ObservableProperty]
    bool isBusy = false;
    [ObservableProperty]
    string message= string.Empty;
    [ObservableProperty]
    bool showMessage= false;
    #endregion

    #region Constructor
    public LoginPageViewModel(INavigationService navigationService,
        UserService userService)
    {
        this.navigationService = navigationService;
        this.userService = userService;

#if DEBUG
        Account = "god";
        Password= "123";
#endif
    }
    #endregion

    #region Method Member
    #region Command Method
    [RelayCommand]
    async Task LoginAsync()
    {
        IsBusy = true;
        await userService.LoginAsync(Account, Password);
        if(userService.APIResult.Status == true)
        {
            ShowMessage= true;
            Message = $"Token: {userService.APIResult.Payload}";
        }
        IsBusy = false;
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
