using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MA47.Dtos.Models;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace MA47.ViewModels;

public partial class MainPageViewModel : ObservableObject, INavigatedAware
{
    public MainPageViewModel(INavigationService navigationService)
    {
        this.navigationService = navigationService;
    }

    [ObservableProperty]
    string title = "使用者登入";
    [ObservableProperty]
    string account = string.Empty;
    [ObservableProperty]
    string password = string.Empty;
    [ObservableProperty]
    string message = string.Empty;
    LoginResponseDto responseDto = new LoginResponseDto();
    private readonly INavigationService navigationService;

    [RelayCommand]
    async Task Login()
    {
        APIResult apiResult = await UserAuthenticationAsync();
        if (apiResult.Status == true)
        {
            responseDto = JsonConvert
                .DeserializeObject<LoginResponseDto>(apiResult.Payload.ToString());
            await WriteLoginResponseAsync();
            Message = $"Token:{responseDto.Token}";
            await Task.Delay(5000);
            await navigationService.NavigateAsync("/HomePage");
        }
        else
        {
            Message = $"錯誤訊息:{apiResult.Message}";
        }
    }

    [RelayCommand]
    async Task GetLoginTokenAsync()
    {
        var success = await ReadLoginResponseAsync();
        if(success == true)
        {
            Message = responseDto.Token;
        }
        else
        {
            Message = $"無法讀取出存取權杖";
        }
    }


    async Task<bool> ReadLoginResponseAsync()
    {
        string filename = Path.Combine(FileSystem.Current.AppDataDirectory,
            "LoginResponse.dat");
        try
        {
            string responseDtoContext = await File.ReadAllTextAsync(filename);
            responseDto = JsonConvert.DeserializeObject<LoginResponseDto>(responseDtoContext);
            return true;
        }
        catch (Exception ex)
        {
            responseDto = new LoginResponseDto();
            return false;
        }
    }

    async Task<bool> WriteLoginResponseAsync()
    {
        string filename = Path.Combine(FileSystem.Current.AppDataDirectory,
            "LoginResponse.dat");
        try
        {
            string responseDtoContext = JsonConvert.SerializeObject(responseDto);
            await File.WriteAllTextAsync(filename, responseDtoContext);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public void OnNavigatedFrom(INavigationParameters parameters)
    {
    }

    public void OnNavigatedTo(INavigationParameters parameters)
    {
    }

    async Task<APIResult> UserAuthenticationAsync()
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
