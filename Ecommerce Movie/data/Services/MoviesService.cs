using Ecommerce_Movie.data.Base;
using Ecommerce_Movie.data.ViewModels;
using Ecommerce_Movie.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_Movie.data.Services
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesServices
    {

        private readonly AppDbContext _context;
        public MoviesService(AppDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var result = await _context.Movies.Include(c => c.Cinema)
                .Include(p => p.Producer)
                .Include(am => am.Actors_Movies).ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n => n.Id == id);

            return result;


        }

        public async Task<MovieViewModelDropDownProducers> GetMovieDropdownsValues()
        {
            var responce = new MovieViewModelDropDownProducers();

            responce.Actors = await _context.Actors.OrderBy(x => x.FullName).ToListAsync();
            responce.Cinemas = await _context.Cinemas.OrderBy(x => x.Name).ToListAsync();
            responce.Producers = await _context.Producers.OrderBy(x => x.FullName).ToListAsync();

            return responce;
        }

        public async Task AddMovieAsync(MovieViewModel data)
        {
            var result = new Movie()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageUrl = data.ImageUrl,
                CinemaId = data.CinemaId,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                MovieCategory = data.MovieCategory,
                ProducerId = data.ProducerId
            };

            await _context.Movies.AddAsync(result);
            await _context.SaveChangesAsync();

            foreach (var actorId in data.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = result.Id,
                    ActorId = actorId
                };
                await _context.Actors_Movies.AddAsync(newActorMovie);
            }

            await _context.SaveChangesAsync();
        }

        public async Task UpdateMovieAsync(MovieViewModel data)
        {

            var dbMovie = await _context.Movies.FirstOrDefaultAsync(x => x.Id == data.Id);

            if (dbMovie != null)
            {
                {
                    dbMovie.Name = data.Name;
                    dbMovie.Description = data.Description;
                    dbMovie.Price = data.Price;
                    dbMovie.ImageUrl = data.ImageUrl;
                    dbMovie.CinemaId = data.CinemaId;
                    dbMovie.StartDate = data.StartDate;
                    dbMovie.EndDate = data.EndDate;
                    dbMovie.MovieCategory = data.MovieCategory;
                    dbMovie.ProducerId = data.ProducerId;
                    await _context.SaveChangesAsync();
                };

                var existingActors = _context.Actors_Movies.Where(x => x.MovieId == data.Id).ToList();
                _context.Actors_Movies.RemoveRange(existingActors);
                await _context.SaveChangesAsync();

                foreach (var actorId in data.ActorIds)
                {
                    var newActorMovie = new Actor_Movie()
                    {
                        MovieId = data.Id,
                        ActorId = actorId
                    };
                    await _context.Actors_Movies.AddAsync(newActorMovie);
                }
                await _context.SaveChangesAsync();
            }
        }
    }
}
