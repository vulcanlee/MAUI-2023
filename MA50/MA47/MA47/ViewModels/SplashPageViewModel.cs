using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MA47.Dtos.Models;
using Newtonsoft.Json;

namespace MA47.ViewModels;

// 使用 dotnet new MVVMItem --namespace MA47 --view-name Splash 產生出來
public partial class SplashPageViewModel : ObservableObject, INavigatedAware
{
    #region Field Member
    private readonly INavigationService navigationService;
    #endregion

    #region Property Member
    [ObservableProperty]
    string currentStatus = "請稍後，正在啟動中";
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
        await Task.Delay(5000);
        var result = await CheckJWTStatusAsync();
        if (result)
        {
            CurrentStatus = $"發現 JWT，切換到首頁";
            await Task.Delay(2000);
            await navigationService.NavigateAsync("HomePage");
        }
        else
        {
            CurrentStatus = $"沒有發現 JWT，準備要登入";
            await Task.Delay(2000);
            await navigationService.NavigateAsync("/MainPage");
        }
    }
    #endregion

    #region Other Method
    async Task<bool> CheckJWTStatusAsync()
    {
        string filename = Path.Combine(FileSystem.Current.AppDataDirectory,
            "LoginResponse.dat");
        try
        {
            LoginResponseDto responseDto;
            string responseDtoContext = await File.ReadAllTextAsync(filename);
            responseDto = JsonConvert.DeserializeObject<LoginResponseDto>(responseDtoContext);
            if (responseDto != null && responseDto.Token != null)
                return true;
            else
                return false;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
    #endregion
    #endregion
}
