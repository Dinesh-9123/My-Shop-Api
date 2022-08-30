using IdentityModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyShopsData.Interfaces;
using MyShopsModels;
using MyShopsServices.Infrastructure.Builders.Interfaces;
using MyShopsServices.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyShopsServices
{
    public  class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IAuthBuilder _authBuilder;
        public AuthService(IAuthBuilder authBuilder, IAuthRepository authRepository)
        {
            _authBuilder = authBuilder; 
            _authRepository = authRepository;
        }
        public async Task<SignUpModel> Login(string username, string password)
        {
            var user = await _authRepository.GetByEmailOrPassword(username, password);
            if(user == null)
            {
                throw new Exception("User not found");
            }
            else
            {
                return _authBuilder.Build(user);
            }
        }

        public async Task<string> SignUp(SignUpModel signUpItem)
        {
            var dto = _authBuilder.Build(signUpItem);

            if(dto.userId > 0)
            {
                var user = await _authRepository.GetByUserId(dto.userId);
                user.email = dto.email;
                user.firstName = dto.firstName;
                user.lastName = dto.lastName;
                user.mobNo = dto.mobNo;
                await _authRepository.UpdateAsync(user);
            }
            else
            {
                var id = await _authRepository.AddAsync(dto);
            }

            return "success";
        }
    }
}
