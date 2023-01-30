using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace MA47.ViewModels;

// 使用 dotnet new MVVMItem --namespace MA47 --view-name Home 產生出來
public partial class HomePageViewModel : ObservableObject, INavigatedAware
{
    #region Field Member
    private readonly INavigationService navigationService;
    #endregion

    #region Property Member
    #endregion

    #region Constructor
    public HomePageViewModel(INavigationService navigationService)
    {
        this.navigationService = navigationService;
    }
    #endregion

    #region Method Member
    #region Command Method
    [RelayCommand]
    async Task LogoutAsync()
    {
        await RemoveJwtAsync();
        await navigationService.NavigateAsync("/MainPage");
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
    async Task RemoveJwtAsync()
    {
        string filename = Path.Combine(FileSystem.Current.AppDataDirectory,
            "LoginResponse.dat");
        try
        {
            File.Delete(filename);
        }
        catch (Exception ex)
        {
        }
    }
    #endregion
    #endregion
}
