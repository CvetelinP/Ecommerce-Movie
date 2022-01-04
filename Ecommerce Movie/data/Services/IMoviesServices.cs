using Ecommerce_Movie.data.Base;
using Ecommerce_Movie.data.ViewModels;
using Ecommerce_Movie.Models;

namespace Ecommerce_Movie.data.Services
{
    public interface IMoviesServices:IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);

        Task<MovieViewModelDropDownProducers> GetMovieDropdownsValues();

        Task AddMovieAsync(MovieViewModel data);

        Task UpdateMovieAsync(MovieViewModel data);

    }
}
