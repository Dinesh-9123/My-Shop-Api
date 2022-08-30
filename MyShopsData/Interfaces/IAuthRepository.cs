using MyShopsDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShopsData.Interfaces
{
    public interface IAuthRepository : IRepository<AuthDto>
    {
        Task<AuthDto> GetByEmailOrPassword(string email,string password);
        Task<AuthDto> GetByUserId(int userId);  
    }
}
