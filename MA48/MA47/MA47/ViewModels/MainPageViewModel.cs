using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MA47.Dtos.Models;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace MA47.ViewModels;

public partial class MainPageViewModel : ObservableObject, INavigatedAware
{
    public MainPageViewModel()
    {
    }

    [ObservableProperty]
    string title = "MA47|使用者登入 MVVM";
    [ObservableProperty]
    string account = string.Empty;
    [ObservableProperty]
    string password = string.Empty;
    [ObservableProperty]
    string message = string.Empty;

    [RelayCommand]
    async Task Login()
    {
        APIResult apiResult = await UserAuthentication();
        if (apiResult.Status == true)
        {
            LoginResponseDto loginResponseDto = JsonConvert
                .DeserializeObject<LoginResponseDto>(apiResult.Payload.ToString());
            Message = $"Token:{loginResponseDto.Token}";
        }
        else
        {
            Message = $"錯誤訊息:{apiResult.Message}";
        }
    }

    public void OnNavigatedFrom(INavigationParameters parameters)
    {
    }

    public void OnNavigatedTo(INavigationParameters parameters)
    {
    }

    async Task<APIResult> UserAuthentication()
    {
        APIResult apiResult = null;
        LoginRequestDto loginRequestDto = new LoginRequestDto()
        {
            Account = Account,
            Password = Password,
        };

        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri("https://blazortw.azurewebsites.net");
        HttpResponseMessage httpResponse = await client.PostAsJsonAsync("/api/Login", loginRequestDto);
        if (httpResponse.IsSuccessStatusCode)
        {
            apiResult = await httpResponse.Content.ReadFromJsonAsync<APIResult>();
            return apiResult;
        }
        else
        {
            apiResult = await httpResponse.Content.ReadFromJsonAsync<APIResult>();
            return apiResult;
        }
    }
}
