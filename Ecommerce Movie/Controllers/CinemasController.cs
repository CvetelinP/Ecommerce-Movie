using Ecommerce_Movie.data.Services;
using Ecommerce_Movie.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_Movie.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemasService _cinemasService;

        public CinemasController(ICinemasService cinemasService)
        {
            this._cinemasService = cinemasService;
        } 
        public async Task<IActionResult> Index()
        {
            var allCinemas = await this._cinemasService.GetAllAsync();
            return View(allCinemas);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Name,Logo,Description")] Cinema cinema)
        {

            if (ModelState.IsValid)
            {

                return View(cinema);
            }
            await _cinemasService.AddAsync(cinema);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Details(int id)
        {

            var cinemaDetails = await _cinemasService.GetByIdAsync(id);

            if (cinemaDetails == null)
            {
                return this.View("NotFound");
            }

            return View(cinemaDetails);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var cinemaDetails = await _cinemasService.GetByIdAsync(id);

            if (cinemaDetails == null)
            {
                return this.View("NotFound");
            }
            return this.View(cinemaDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Id,Name,Logo,Description")] Cinema cinema, int id)
        {

            if (ModelState.IsValid)
            {

                return View(cinema);
            }
            await _cinemasService.UpdateAsync(id, cinema);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var cinemaDetails = await _cinemasService.GetByIdAsync(id);

            if (cinemaDetails == null)
            {
                return this.View("NotFound");
            }
            return this.View(cinemaDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cinemaDetails = await _cinemasService.GetByIdAsync(id);
            if (cinemaDetails == null)
            {
                return this.View("NotFound");
            }

            await _cinemasService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
