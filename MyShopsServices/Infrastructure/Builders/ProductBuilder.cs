using AutoMapper;
using MyShopsDomain;
using MyShopsModels;
using MyShopsServices.Infrastructure.Builders.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShopsServices.Infrastructure.Builders
{
    public class ProductBuilder : IProductBuilder
    {
        private readonly IMapper _mapper;
        public ProductBuilder(IMapper mapper)
        {
            _mapper = mapper;
        }
        public ProductDto Buid(ProductModel product)
        {
            return _mapper.Map<ProductDto>(product);
        }

        public ProductModel Build(ProductDto product)
        {
            return _mapper.Map<ProductModel>(product);
        }
    }
}
