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
    public class CartRepository : BaseRepository<CartDto>, ICartRepository
    {
        public CartRepository(IDatabaseFactory databaseFactory) 
            : base(databaseFactory)
        {
        }

        public async Task<string> AddItem(CartDto item)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@UserId", item.userId);
            parameters.Add("@Id", item.id);
            parameters.Add("@Name", item.name);
            parameters.Add("@ImgUrl", item.imgUrl);
            parameters.Add("@Price", item.price);
            parameters.Add("@Description", item.description);
            parameters.Add("@Quantity", item.quantity);
            var results = await DataContext.QueryAsync("[Users].[AddToCart]", param: parameters, commandType: System.Data.CommandType.StoredProcedure);
            if (results != null)
            {
                return "Success";
            }
            else
            {
                return "Failed";
            }
        }

        public async Task<string> DeleteItem(int userId, int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@UserId", userId);
            parameters.Add("@Id", id);
            var results = await DataContext.QueryAsync("[Users].[DeleteFromCart]", param: parameters, commandType: System.Data.CommandType.StoredProcedure);
            if (results != null)
            {
                return "Success";
            }
            else
            {
                return "Failed";
            }
        }

        public async Task<List<CartDto>> GetByUserId(int userId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@UserId", userId);
            var results = await DataContext.QueryAsync<CartDto>("[Users].[GetCart]", param: parameters, commandType: System.Data.CommandType.StoredProcedure);
            return results.ToList();
        }

        public async Task<CartDto> GetByUserIDAndItemId(int userId, int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@UserId", userId);
            parameters.Add("@Id", id);
            var results = await DataContext.QueryAsync<CartDto>("[Users].[GetCartByUserIdAndId]", param: parameters, commandType: System.Data.CommandType.StoredProcedure);
            return results.ToList().FirstOrDefault();
        }

        public async Task<string> UpdateItem(int userId, int id, int quantity)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@UserId", userId);
            parameters.Add("@Id", id);
            parameters.Add("@Quantity", quantity);
            var results = await DataContext.QueryAsync("[Users].[UpdateCart]", param: parameters, commandType: System.Data.CommandType.StoredProcedure);
            if(results != null)
            {
                return "Success";
            }
            else
            {
                return "Failed";
            }
        }
    }
}
