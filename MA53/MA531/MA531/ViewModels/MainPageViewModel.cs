using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MA531.Helpers;
using Microsoft.Identity.Client;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MA531.ViewModels;

public partial class MainPageViewModel : ObservableObject, INavigatedAware
{
    #region Field Member
    private int _count;
    private readonly INavigationService navigationService;

    [ObservableProperty]
    string title = "Main Page";

    [ObservableProperty]
    string text = "Click me";
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
    private async Task Count()
    {
        try
        {
            var authService = new AuthService();
            var result = await authService.LoginAsync(CancellationToken.None);
            var token = result?.IdToken; // AccessToken also can be used
            
            #region test
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", result.AccessToken);
            HttpResponseMessage response = await client
                .GetAsync("https://graph.microsoft.com/v1.0/me");

            var bar = response.IsSuccessStatusCode;
            var res = await response.Content.ReadAsStringAsync();
            Console.WriteLine(res);
            #endregion

            if (token != null)
            {
                var handler = new JwtSecurityTokenHandler();
                var data = handler.ReadJwtToken(token);
                var claims = data.Claims.ToList();
                if (data != null)
                {
                    var stringBuilder = new StringBuilder();
                    stringBuilder.AppendLine($"Name: {data.Claims.FirstOrDefault(x => x.Type.Equals("name"))?.Value}");
                    stringBuilder.AppendLine($"Email: {data.Claims.FirstOrDefault(x => x.Type.Equals("preferred_username"))?.Value}");

                    Text = stringBuilder.ToString();
                    //await Toast.Make(stringBuilder.ToString()).Show();
                }
            }
        }
        catch (MsalClientException ex)
        {
            //await Toast.Make(ex.Message).Show();
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
