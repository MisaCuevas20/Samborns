﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Samborns.Models.Context;
using API_Samborns.Models.Entities;

namespace API_Samborns.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreasController : ControllerBase
    {
        private readonly EmpresaContext _context;

        public AreasController(EmpresaContext context)
        {
            _context = context;
        }

        // GET: api/Areas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Area>>> GetArea()
        {
            return await _context.Area.ToListAsync();
        }

        // GET: api/Areas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Area>> GetArea(int id)
        {
            var area = await _context.Area.FindAsync(id);

            if (area == null)
            {
                return NotFound();
            }

            return area;
        }

        // PUT: api/Areas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArea(int id, Area area)
        {
            if (id != area.Id)
            {
                return BadRequest();
            }

            _context.Entry(area).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AreaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Areas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Area>> PostArea(Area area)
        {
            _context.Area.Add(area);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArea", new { id = area.Id }, area);
        }

        // DELETE: api/Areas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArea(int id)
        {
            var area = await _context.Area.FindAsync(id);
            if (area == null)
            {
                return NotFound();
            }

            _context.Area.Remove(area);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AreaExists(int id)
        {
            return _context.Area.Any(e => e.Id == id);
        }
    }
}
