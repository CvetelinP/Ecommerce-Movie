using Ecommerce_Movie.data.Services;
using Ecommerce_Movie.data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerce_Movie.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesServices _moviesService;

        public MoviesController(IMoviesServices moviesService)
        {
            this._moviesService = moviesService;
        }
        public async Task<IActionResult> Index()
        {
            var allMovies = await this._moviesService.GetAllAsync(n => n.Cinema);

            return View(allMovies);
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var allMovies = await this._moviesService.
                GetAllAsync(n => n.Cinema);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allMovies.Where(x =>
                    x.Name.Contains(searchString) || x.Description.Contains(searchString)).ToList();

                return this.View("Index", filteredResult);
            } 

            return View("Index", allMovies);
        }

        public async Task<IActionResult> Details(int id)
        {
            var movieDetails = await this._moviesService.GetMovieByIdAsync(id);

            return this.View(movieDetails);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {

            var movieDropDownsData = await _moviesService.GetMovieDropdownsValues();

            ViewBag.Cinemas = new SelectList(movieDropDownsData.Cinemas,"Id","Name");
            ViewBag.Producers = new SelectList(movieDropDownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropDownsData.Actors, "Id", "FullName");
            

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MovieViewModel movie)
        {
            if (!ModelState.IsValid)
            {
                var movieDropDownsData = await _moviesService.GetMovieDropdownsValues();

                ViewBag.Cinemas = new SelectList(movieDropDownsData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropDownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropDownsData.Actors, "Id", "FullName");

                return View(movie);
            }

            await _moviesService.AddMovieAsync(movie);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var movieDetails = await _moviesService.GetMovieByIdAsync(id);

            if (movieDetails ==null)
            {
                return View("NotFound");
            }

            var responce = new MovieViewModel()
            {
                Id = movieDetails.Id,
                Name = movieDetails.Name,
                Description = movieDetails.Description,
                ProducerId = movieDetails.ProducerId,
                MovieCategory = movieDetails.MovieCategory,
                Price = movieDetails.Price,
                ImageUrl = movieDetails.ImageUrl,
                CinemaId = movieDetails.CinemaId,
                ActorIds = movieDetails.Actors_Movies.Select(x =>x.ActorId).ToList(),
                StartDate = movieDetails.StartDate,
                EndDate = movieDetails.EndDate,

            };


            var movieDropDownsData = await _moviesService.GetMovieDropdownsValues();

            ViewBag.Cinemas = new SelectList(movieDropDownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropDownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropDownsData.Actors, "Id", "FullName");


            return this.View(responce);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,MovieViewModel movie)
        {

            if (id !=movie.Id)
            {
                return this.View("NotFound");
            }
            if (!ModelState.IsValid)
            {
                var movieDropDownsData = await _moviesService.GetMovieDropdownsValues();

                ViewBag.Cinemas = new SelectList(movieDropDownsData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropDownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropDownsData.Actors, "Id", "FullName");

                return View(movie);
            }

            await _moviesService.UpdateMovieAsync(movie);


            return RedirectToAction(nameof(Index));
        }

    }
}
