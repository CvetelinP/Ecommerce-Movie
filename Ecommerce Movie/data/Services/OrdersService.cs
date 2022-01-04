using Ecommerce_Movie.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_Movie.data.Services
{
    public class OrdersService : IOrdersService
    {

        private readonly AppDbContext _context;

        public OrdersService(AppDbContext context)
        {
            this._context = context;
        }
        public async Task StoreOrderAsync(List<ShoppingCartItem> shoppingCartItems, string userId, string userEmailAddress)
        {
            var order = new Order()
            {
                UserId = userId,
                Email = userEmailAddress,

            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach (var item in shoppingCartItems)
            {
                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    MovieId = item.Movie.Id,
                    OrderId = order.Id,
                    Price = item.Movie.Price,
                };

              await  _context.OrderItems.AddAsync(orderItem);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<List<Order>> GetOrdersByUserIdAsync(string userId)
        {
            var orders = await _context.Orders.Include(x => x.OrderItems)
                .ThenInclude(x=>x.Movie)
                .Where(x=>x.UserId ==userId).ToListAsync();

            return orders;
        }
    }
}
