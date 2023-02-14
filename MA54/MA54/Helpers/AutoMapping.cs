using AutoMapper;
using MA54.Dtos;
using MA54.Models;

namespace MA54.Helpers;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        #region DTO - Model 對應關係宣告
        CreateMap<Product, ProductDto>();
        CreateMap<ProductDto, Product>();
        #endregion
    }
}
