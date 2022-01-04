using Ecommerce_Movie.data.Services;
using Ecommerce_Movie.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_Movie.Controllers
{
    public class ActorsController : Controller
    {

        private readonly IActorsService _actorsService;

        public ActorsController(IActorsService actorsService)
        {
            this._actorsService = actorsService;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _actorsService.GetAllAsync();

            return View(data);
        }

        //Get :Actors/Create

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureUrl,Bio")] Actor actor)
        {

            if (ModelState.IsValid)
            {

                return View(actor);
            }
            await _actorsService.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Details(int id)
        {

            var actorDetails = await _actorsService.GetByIdAsync(id);

            if (actorDetails == null)
            {
                return this.View("NotFound");
            }

            return View(actorDetails);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _actorsService.GetByIdAsync(id);

            if (actorDetails == null)
            {
                return this.View("NotFound");
            }
            return this.View(actorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Id,FullName,ProfilePictureUrl,Bio")] Actor actor ,int id)
        {

            if (ModelState.IsValid)
            {

                return View(actor);
            }
            await _actorsService.UpdateAsync(id,actor);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _actorsService.GetByIdAsync(id);

            if (actorDetails == null)
            {
                return this.View("NotFound");
            }
            return this.View(actorDetails);
        }

        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await _actorsService.GetByIdAsync(id);
            if (actorDetails == null)
            {
                return this.View("NotFound");
            }

            await _actorsService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }


}
