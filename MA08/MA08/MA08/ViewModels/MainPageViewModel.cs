using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MA08.ViewModels;

public partial class MainPageViewModel : ObservableObject, INavigatedAware
{
    // 可用於 Data Binding 中使用的命令物件
    [RelayCommand]
    void GenerateSayHello() // 將會產生 GenerateSayHelloCommand 物件
    {
        SayHello = $"你好 {FullName} {DateTime.Now}";
    }

    #region 姓氏 屬性
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(FullName))]
    string lastName;  // 將會產生 LastName 屬性
    #endregion

    #region 名字 屬性
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(FullName))]
    string firstName;  // 將會產生 FirstName 屬性
    #endregion

    #region 要問安的文字 屬性
    [ObservableProperty]
    string sayHello;
    #endregion

    #region 全名 屬性
    // 使用運算式主體定義來實作屬性 get 和 set 存取子
    public string FullName => $"{LastName} {FirstName}";
    #endregion

    public void OnNavigatedFrom(INavigationParameters parameters)
    {
    }

    public void OnNavigatedTo(INavigationParameters parameters)
    {
    }
}
