using AutoMapper;
using MyShopsDomain;
using MyShopsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShopsServices.Infrastructure.Builders.MapperProfiles
{
    public class ModelToDtoMappingProfile : Profile
    {
        public ModelToDtoMappingProfile()
        {
            CreateMap<ProductModel, ProductDto>();
            CreateMap<SignUpModel, AuthDto>();
            CreateMap<CartItem, MyCartDto>();
        }
    }
}
