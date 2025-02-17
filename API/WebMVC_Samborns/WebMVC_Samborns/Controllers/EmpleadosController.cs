using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebMVC_Samborns.Models.Entities;
using WebMVC_Samborns.Services;

namespace WebMVC_Samborns.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly EmpleadosService _empleadosService;
        private readonly AreaService _areaService;

        public EmpleadosController(EmpleadosService empleadosService, AreaService areaService)
        {
            _empleadosService = empleadosService;
            _areaService = areaService;
        }

        // GET: Empleados
        public async Task<IActionResult> Index()
        {
            var empleados = await _empleadosService.GetEmpleadosAsync();

            return View(empleados);
        }

        // GET: Empleados/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var empleado = await _empleadosService.GetEmpleadoByIdAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // GET: Empleados/Create
        public async Task<IActionResult> Create()
        {
            var areas = await _areaService.GetAreasAsync();
            ViewData["NombreArea"] = new SelectList(areas, "Id", "Nombre");
            return View();
        }

        // POST: Empleados/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Edad,IdArea,FechaIngreso")] Empleados empleados)
        {
            if (ModelState.IsValid)
            {
                await _empleadosService.CreateEmpleadoAsync(empleados);
                return RedirectToAction(nameof(Index));
            }
            return View(empleados);
        }

        // GET: Empleados/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var empleado = await _empleadosService.GetEmpleadoByIdAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }

            var areas = await _areaService.GetAreasAsync();
            ViewBag.area = new SelectList(areas, "Id", "Nombre", empleado.IdArea);

            return View(empleado);
        }


        // POST: Empleados/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Edad,IdArea,FechaIngreso")] Empleados empleados)
        {
           
            if (id != empleados.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                bool updated = await _empleadosService.UpdateEmpleadoAsync(id, empleados);
                if (!updated)
                {
                    return NotFound();
                }

                return RedirectToAction(nameof(Index));
            }

            var areas = await _areaService.GetAreasAsync();
            ViewBag.area = new SelectList(areas, "Id", "Nombre", empleados.IdArea);
            return View(empleados);
        }



        // GET: Empleados/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var empleado = await _empleadosService.GetEmpleadoByIdAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            bool deleted = await _empleadosService.DeleteEmpleadoAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
