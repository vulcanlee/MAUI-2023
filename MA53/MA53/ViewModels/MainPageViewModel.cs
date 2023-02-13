using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MA53.Helpers;
using System.Web;

namespace MA53.ViewModels;

public partial class MainPageViewModel : ObservableObject, INavigatedAware
{
    #region Field Member
    private readonly INavigationService navigationService;

    [ObservableProperty]
    string title = "Main Page";

    #endregion

    #region Property Member
    [ObservableProperty]
    string accessToken = string.Empty;
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
    void Test()
    {
        CookieHelper cookieHelper = new CookieHelper();
        cookieHelper.CleanCookie();
    }
    [RelayCommand]
    private async Task LoginAsync()
    {
        // Web 驗證器
        // https://learn.microsoft.com/zh-tw/dotnet/maui/platform-integration/communication/authentication?view=net-maui-7.0&tabs=windows

        try
        {
            var bar = MainThread.IsMainThread;
        
            CookieHelper cookieHelper = new CookieHelper();
            cookieHelper.CleanCookie();

            string loginEndpoint = $"https://192.168.82.142:5084/mobileauth/Microsoft";
            string loginEndpointUrlEncode = HttpUtility.UrlEncode(loginEndpoint);
            string logoutUrl = $"https://login.microsoftonline.com/common/oauth2/logout" +
                $"?post_logout_redirect_uri={loginEndpointUrlEncode}";
            WebAuthenticatorResult authResult = 
                await WebAuthenticator.Default.AuthenticateAsync(
                new Uri(loginEndpoint),
                new Uri($"{MagicValue.CALLBACK_SCHEME}://"));

            AccessToken = authResult?.AccessToken;

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
