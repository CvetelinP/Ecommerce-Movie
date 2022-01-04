using Ecommerce_Movie.data.Services;
using Ecommerce_Movie.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_Movie.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducersService _producerService;

        public ProducersController(IProducersService producertService)
        {
            this._producerService = producertService;
        }

        public async Task<IActionResult> Index()
        {
            var allProducents = await this._producerService.GetAllAsync();

            return this.View(allProducents);

        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureUrl,Bio")] Producer producer)
        {

            if (ModelState.IsValid)
            {

                return View(producer);
            }

            await _producerService.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Details(int id)
        {

            var producerDetails = await _producerService.GetByIdAsync(id);

            if (producerDetails == null)
            {
                return this.View("NotFound");
            }

            return View(producerDetails);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var producerDetails = await _producerService.GetByIdAsync(id);

            if (producerDetails == null)
            {
                return this.View("NotFound");
            }

            return this.View(producerDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Id,FullName,ProfilePictureUrl,Bio")] Producer producer, int id)
        {

            if (ModelState.IsValid)
            {

                return View(producer);
            }

            await _producerService.UpdateAsync(id, producer);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var producerDetails = await _producerService.GetByIdAsync(id);

            if (producerDetails == null)
            {
                return this.View("NotFound");
            }

            return this.View(producerDetails);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producerDetails = await _producerService.GetByIdAsync(id);

            if (producerDetails == null)
            {
                return this.View("NotFound");
            }

            await _producerService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

