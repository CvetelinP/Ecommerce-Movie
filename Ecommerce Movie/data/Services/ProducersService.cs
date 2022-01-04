using Ecommerce_Movie.data.Base;
using Ecommerce_Movie.Models;

namespace Ecommerce_Movie.data.Services
{
    public class ProducersService : EntityBaseRepository<Producer>, IProducersService
    {
        public ProducersService(AppDbContext context) : base(context)
        {
        }
    }
}
