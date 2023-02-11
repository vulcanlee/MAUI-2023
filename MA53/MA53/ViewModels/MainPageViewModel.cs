using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MA53.Helpers;

namespace MA53.ViewModels;

public partial class MainPageViewModel : ObservableObject, INavigatedAware
{
    #region Field Member
    private readonly INavigationService navigationService;

    [ObservableProperty]
    string title = "Main Page";

    #endregion

    #region Property Member
    #endregion

    #region Constructor
    public MainPageViewModel(INavigationService navigationService)
    {
        this.navigationService = navigationService;
    }
    #endregion

    #region Method Member
    #region Command Method
    [RelayCommand]
    private async Task LoginAsync()
    {
        // Web 驗證器
        // https://learn.microsoft.com/zh-tw/dotnet/maui/platform-integration/communication/authentication?view=net-maui-7.0&tabs=windows

        try
        {
            WebAuthenticatorResult authResult = 
                await WebAuthenticator.Default.AuthenticateAsync(
                new Uri("http://192.168.31.207:5081/mobileauth/Microsoft"),
                new Uri($"{MagicValue.CALLBACK_SCHEME}://"));

            string accessToken = authResult?.AccessToken;

            // Do something with the token
        }
        catch (TaskCanceledException e)
        {
            // Use stopped auth
        }
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
