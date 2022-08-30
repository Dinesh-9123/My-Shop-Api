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
    public class DtoToModelMappingProfile : Profile
    {
        public DtoToModelMappingProfile()
        {
            CreateMap<ProductDto, ProductModel>();
            CreateMap<AuthDto, SignUpModel>();
            CreateMap<MyCartDto, CartItem>();
            
        }
    }
}
