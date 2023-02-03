using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MA52;

public partial class MainPageViewModel : ObservableObject
{
    [ObservableProperty]
    string text = "Click me";

    [RelayCommand]
    void Count()
    { }
}
