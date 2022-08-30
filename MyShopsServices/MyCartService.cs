using MyShopsData.Interfaces;
using MyShopsModels;
using MyShopsServices.Infrastructure.Builders.Interfaces;
using MyShopsServices.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShopsServices
{
    public class MyCartService : IMyCartService
    {
        private readonly IMyCartRepository _myCartRepository;
        private readonly ICartBuilder _cartBuilder;

        public MyCartService(IMyCartRepository myCartRepository,ICartBuilder cartBuilder)
        {
            _myCartRepository = myCartRepository;   
            _cartBuilder = cartBuilder;
        }

        public async Task<CartDataModel> GetAll(int userId)
        {
            var items = new List<CartModel>();
            var dto = (await _myCartRepository.GetByUserId(userId)).ToList();
            int i = 0;
            while (i < dto.Count)
            {
                var item = new CartModel();
                item.id = dto[i].id;
                item.quantity = dto[i].quantity;
                item.name = dto[i].name;
                item.description = dto[i].description;
                item.price = dto[i].price;
                item.imgUrl = dto[i].imgUrl;
                items.Add(item);
                i++;
            }

            var totalAmount = 0;
            for (int j = 0; j < items.Count; j++)
            {
                totalAmount += items[j].price * items[j].quantity;
            }
            var model = new CartDataModel();
            model.items = items;
            model.totalAmount = totalAmount;
            return model;
        }
        public async Task<string> AddItem(CartItem cartItem)
        {
            var dto = await _myCartRepository.GetByUserIDAndItemId(cartItem.userId, cartItem.id);
            if (dto == null)
            {
                var itemToDto = _cartBuilder.Build(cartItem);
                itemToDto.quantity = 1;
                return await _myCartRepository.AddItem(itemToDto);
                
            }
            else
            {
                dto.quantity += 1;
                return await _myCartRepository.UpdateItem(dto.userId, dto.id, dto.quantity);
            }
        }
        public async Task<string> RemoveItem(CartItem cartItem)
        {
            var dto = _cartBuilder.Build(cartItem);
            if(dto.quantity > 1)
            {
                dto.quantity -= 1;
                await _myCartRepository.UpdateItem(dto.userId, dto.id, dto.quantity); 
                return "success";
            }
            else
            {
                await _myCartRepository.DeleteItem(dto.userId, dto.id);
                return "success";
            }
        }

    }
}
