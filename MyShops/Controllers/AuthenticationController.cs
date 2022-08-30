using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShops.Authentication;
using MyShops.Models;
using MyShopsModels;
using MyShopsServices.Infrastructure.Interfaces;

namespace MyShops.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly TokenManager _tokenManager;
        public AuthenticationController(IAuthService authService, TokenManager tokenManager)
        {
            _authService = authService;
            _tokenManager = tokenManager;   
        }

        [HttpGet]
        [Route("[controller]Login")]
        public async Task<ResponseWrapper<loginResponseItem>> Login(string email, string password)
        {
            var response = new ResponseWrapper<loginResponseItem>();
            try
            {
                var res =  await _authService.Login(email, password);
                var name = String.Concat(res.firstName + " ", res.lastName);
                var token = TokenManager.GenerateToken(res.roles, res.userId,name, res.mobNo, res.firstName, res.lastName);
                var responeLogin = new loginResponseItem
                {
                    email = email,
                    token = token,
                    expiresIn = 120
                };
                response.Set(responeLogin);
            }
            catch (Exception ex)
            {
                response.Set(ex);
            }
            return response;
        }

        [HttpPost]
        [Route("[controller]SignUp")]
        public async Task<ResponseWrapper<string>> SignUp(SignUpModel signUpItem)
        {
            var response = new ResponseWrapper<string>();
            try
            {
                response.Set(await _authService.SignUp(signUpItem));
            }
            catch (Exception ex)
            {
                response.Set(ex);
            }
            return response;
        }


        [HttpGet]
        [Route("[controller]GetRole")]

        public async Task<ResponseWrapper<int>> GetRole()
        {
            var response = new ResponseWrapper<int>();
            try
            {
                response.Set(_tokenManager.GetUserRoleId());
            }
            catch (Exception ex)
            {
                response.Set(ex);
            }
            return response;
        }
    }
}
