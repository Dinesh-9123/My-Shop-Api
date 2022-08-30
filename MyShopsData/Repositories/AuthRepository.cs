using Dapper;
using MyShopsData.Interfaces;
using MyShopsDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShopsData.Repositories
{
    public class AuthRepository : BaseRepository<AuthDto>, IAuthRepository
    {
        public AuthRepository(IDatabaseFactory databaseFactory) 
            : base(databaseFactory)
        {
        }

        public async Task<AuthDto> GetByEmailOrPassword(string email, string password)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Email", email);
            parameters.Add("@Password", password);
            var results = await DataContext.QueryAsync<AuthDto>("[auth].[SignUpOrLogin]", param: parameters, commandType: System.Data.CommandType.StoredProcedure);
            return results.FirstOrDefault();
        }

        public async Task<AuthDto> GetByUserId(int userId)
        {
            return await DataContext.QuerySingleOrDefault($"select * from [auth].[Users] Where userId = {userId}");
        }
    }
}
