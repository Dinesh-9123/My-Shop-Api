using MyShopsData.Interfaces;
using MyShopsDomain;
using MyShopsModels;
using MyShopsServices.Infrastructure.Builders.Interfaces;
using MyShopsServices.Infrastructure.Interfaces;

namespace MyShopsServices
{
    public class ProductsService : IProductsService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductBuilder _productBuilder;
        public ProductsService(
             IProductRepository productRepository
            ,IProductBuilder productBuilder)
        {
            _productRepository = productRepository;
            _productBuilder = productBuilder;
        }

        public async Task<int> Add(ProductModel item, int roleId)
        {
            if(roleId != 1)
            {
                throw new Exception("Only user can add or update products");
            }
            else
            {
                var dto = await _productRepository.GetById(item.id);
                if(dto != null)
                {
                    dto.name = item.name;
                    dto.price = item.price;
                    dto.imgUrl = item.imgUrl;
                    dto.description = item.description;

                    await _productRepository.UpdateAsync(dto);
                    return dto.id;
                }
                else
                {
                    var product = new ProductDto()
                    {
                        name = item.name,
                        price = item.price,
                        imgUrl = item.imgUrl,
                        description = item.description,
                    };
                    return await _productRepository.AddAsync(product);
                }
            }
        }

        public async Task<string> Delete(ProductModel item, int roleId)
        {
            if(roleId != 1)
            {
                throw new Exception("Only user can add or update products");
            }
            else
            {
                var dto = _productBuilder.Buid(item);
                await _productRepository.DeleteAsync(dto);
                return "success";
            }
        }

        public async Task<List<ProductModel>> GetAllProducts()
        {
            var response = (await _productRepository.GetAllAsync()).ToList();
            return response.Select((item) => _productBuilder.Build(item)).ToList();
        }

        public async Task<ProductModel> GetById(int id)
        {
            var result = await _productRepository.GetAsync(id);
            return _productBuilder.Build(result);
        }
    }
}