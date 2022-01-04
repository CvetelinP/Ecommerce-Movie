using Ecommerce_Movie.data.Base;
using Ecommerce_Movie.Models;

namespace Ecommerce_Movie.data.Services
{
    public class ActorsService : EntityBaseRepository<Actor>, IActorsService
    {
        private readonly AppDbContext _context;

        public ActorsService(AppDbContext context) : base(context)
        {

        }





    }
}
