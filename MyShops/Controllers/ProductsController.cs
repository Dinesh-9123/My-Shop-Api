using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShops.Models;
using MyShopsModels;
using MyShopsServices.Infrastructure.Interfaces;

namespace MyShops.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;
        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        [Route("[controller]GetAll")]
        public async Task<ResponseWrapper<List<ProductModel>>> GetAll()
        {
           var response = new ResponseWrapper<List<ProductModel>>();
            try
            {
                response.Set(await _productsService.GetAllProducts());
            }
            catch (Exception ex)
            {
                response.Set(ex);
            }
            return response;
        }

    }
}
