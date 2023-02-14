using AutoMapper;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MA54.Dtos;
using MA54.Models;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace MA54.ViewModels;

public partial class MainPageViewModel : ObservableObject, INavigatedAware
{
    #region Field Member
    private int _count;
    private readonly INavigationService navigationService;
    private readonly IMapper mapper;
    [ObservableProperty]
    string title = "Main Page";

    [ObservableProperty]
    string text = "Click me";
    #endregion

    #region Property Member
    #endregion

    #region Constructor
    public MainPageViewModel(INavigationService navigationService,
        IMapper mapper)
    {
        this.navigationService = navigationService;
        this.mapper = mapper;
    }
    #endregion

    #region Method Member
    #region Command Method
    [RelayCommand]
    private async Task Count()
    {
        APIResult apiReslut = new();
        Text = "請稍後 ...";
        HttpClient client = new HttpClient();
        var responseMessage = await client
         .GetAsync("https://blazortw.azurewebsites.net/api/SampleAutoMapper");
        apiReslut = await responseMessage.Content.ReadFromJsonAsync<APIResult>();
        if (responseMessage.IsSuccessStatusCode)
        {
            if (apiReslut.Status == true)
            {
                List<ProductDto> productDtos = JsonConvert
                    .DeserializeObject<List<ProductDto>>(
                    apiReslut.Payload.ToString());
                List<Product> products = mapper.Map<List<Product>>(productDtos);
                Text = $"取得 Product 筆數 : {products.Count}";

                foreach (var item in products)
                {
                    Text += $",{item.Name}";
                }
            }
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
