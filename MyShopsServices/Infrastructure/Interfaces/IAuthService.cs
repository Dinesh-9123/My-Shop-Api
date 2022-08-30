using MyShopsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShopsServices.Infrastructure.Interfaces
{
    public interface IAuthService
    {
        Task<SignUpModel> Login(string username, string password);
        Task<string> SignUp(SignUpModel signUpItem);
    }
}
