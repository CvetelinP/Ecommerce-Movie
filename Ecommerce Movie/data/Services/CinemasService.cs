using Ecommerce_Movie.data.Base;
using Ecommerce_Movie.Models;

namespace Ecommerce_Movie.data.Services
{
    public class CinemasService : EntityBaseRepository<Cinema>, ICinemasService
    {
        public CinemasService(AppDbContext context) : base(context)
        {
        }
    }
}
