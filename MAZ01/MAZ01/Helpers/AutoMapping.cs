using AutoMapper;
using MAZ01.Dtos;
using MAZ01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAZ01.Helpers;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        #region DTO - Model
        CreateMap<Product, ProductDto>();
        CreateMap<ProductDto, Product>();
        #endregion
    }
}
