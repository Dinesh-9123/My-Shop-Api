using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShops.Authentication;
using MyShops.Models;
using MyShopsModels;
using MyShopsServices.Infrastructure.Interfaces;

namespace MyShops.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    
    public class CartController : ControllerBase
    {
        private readonly TokenManager _tokenManger;
        private readonly IMyCartService _myCartService;
        public CartController(TokenManager tokenManger, IMyCartService myCartService)
        {
            _tokenManger = tokenManger;
            _myCartService = myCartService;
        }

        [HttpGet]
        [Route("[controller]GetAll")]
        public async Task<ResponseWrapper<CartDataModel>> GetAll()
        {
            var response = new ResponseWrapper<CartDataModel>();
            try
            {
                response.Set(await _myCartService.GetAll(_tokenManger.UserId));
            }
            catch (Exception ex)
            {
                response.Set(ex);
            }
            return response;
        }

        [HttpPost]
        [Route("[controller]RemoveItem")]
        public async Task<ResponseWrapper<string>> RemoveItem(CartModel cartItem)
        {
            var response = new ResponseWrapper<string>();
            try
            {
                var cart = new CartItem();
                cart.description = cartItem.description;
                cart.id = cartItem.id;
                cart.quantity = cartItem.quantity;
                cart.imgUrl = cartItem.imgUrl;
                cart.price = cartItem.price;
                cart.id = cartItem.id;
                cart.userId = _tokenManger.UserId;

                response.Set(await _myCartService.RemoveItem(cart));
            }
            catch (Exception ex)
            {
                response.Set(ex);
            }
            return response;
        }

        [HttpPost]
        [Route("[controller]AddItem")]
        public async Task<ResponseWrapper<string>> AddItem(CartModel cartItem)
        {
            var response = new ResponseWrapper<string>();
            try
            {
                var cart = new CartItem();
                cart.description = cartItem.description;
                cart.name = cartItem.name;
                cart.id = cartItem.id;
                cart.quantity = cartItem.quantity;
                cart.imgUrl = cartItem.imgUrl;
                cart.price = cartItem.price;
                cart.id = cartItem.id;
                cart.userId = _tokenManger.UserId;
                response.Set(await _myCartService.AddItem(cart)); 
            }
            catch (Exception ex)
            {
                response.Set(ex);
            }
            return response;
        }
    }
}
