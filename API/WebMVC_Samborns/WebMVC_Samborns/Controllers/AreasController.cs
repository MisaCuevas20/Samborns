using Microsoft.AspNetCore.Mvc;
using WebMVC_Samborns.Models.Entities;
using WebMVC_Samborns.Services;

namespace WebMVC_Samborns.Controllers
{
    public class AreasController : Controller
    {
        private readonly AreaService _areaService;

        public AreasController(AreaService areaService)
        {
            _areaService = areaService;
        }

        // GET: Areas
        public async Task<IActionResult> Index()
        {
            var areas = await _areaService.GetAreasAsync();
            return View(areas);
        }

        // GET: Areas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var area = await _areaService.GetAreaByIdAsync(id.Value);
            if (area == null) return NotFound();

            return View(area);
        }

        // GET: Areas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Areas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] Area area)
        {
            if (ModelState.IsValid)
            {
                var success = await _areaService.CreateAreaAsync(area);
                if (success) return RedirectToAction(nameof(Index));
            }
            return View(area);
        }

        // GET: Areas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var area = await _areaService.GetAreaByIdAsync(id.Value);
            if (area == null) return NotFound();

            return View(area);
        }

        // POST: Areas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] Area area)
        {
            if (id != area.Id) return NotFound();

            if (ModelState.IsValid)
            {
                var success = await _areaService.UpdateAreaAsync(area);
                if (success) return RedirectToAction(nameof(Index));
            }
            return View(area);
        }

        // GET: Areas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var area = await _areaService.GetAreaByIdAsync(id.Value);
            if (area == null) return NotFound();

            return View(area);
        }

        // POST: Areas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var success = await _areaService.DeleteAreaAsync(id);
            if (success) return RedirectToAction(nameof(Index));

            return NotFound();
        }
    }
}
