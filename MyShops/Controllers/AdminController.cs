using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShops.Authentication;
using MyShops.Models;
using MyShopsModels;
using MyShopsServices.Infrastructure.Interfaces;

namespace MyShops.Controllers
{
   // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IProductsService _productsService;
        private readonly TokenManager _tokenManager;
        public AdminController(IProductsService productsService, TokenManager tokenManager)
        {
            _productsService = productsService;
            _tokenManager = tokenManager;
        }

        [HttpGet]
        [Route("[controller]GetById")]
        public async Task<ResponseWrapper<ProductModel>> GetById(int id)
        {
            var response = new ResponseWrapper<ProductModel>();
            try
            {
                response.Set(await _productsService.GetById(id));
            }
            catch (Exception ex)
            {
                response.Set(ex);
            }
            return response;
        }

        [HttpPost]
        [Route("[controller]Add")]
        public async Task<ResponseWrapper<int>> Post(ProductModel item)
        {
            var response = new ResponseWrapper<int>();
            try
            {
                response.Set(await _productsService.Add(item,1));
            }
            catch (Exception ex)
            {
                response.Set(ex);
            }
            return response;
        }

        [HttpDelete]
        [Route("[controller]Delete")]
        public async Task<ResponseWrapper<string>> Delete(ProductModel item)
        {
            var response = new ResponseWrapper<string>();
            try
            {
                response.Set(await _productsService.Delete(item,GetRole()));
            }
            catch (Exception ex)
            {
                response.Set(ex);
            }
            return response;
        }

        private int GetRole()
        {
            var role = _tokenManager.GetUserRoleId();
            return role;
        }
    }
}
