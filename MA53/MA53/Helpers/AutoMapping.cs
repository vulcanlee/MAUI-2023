using AutoMapper;
using MA53.Models;
using MAZ01.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA53.Helpers
{
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
}
