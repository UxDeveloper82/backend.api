using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepairsController : ControllerBase
    {
        private readonly DataContext _context;

        public RepairsController(DataContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetRepairs()
        {
            var repairs = await _context.Repairs.ToListAsync();
            return Ok(repairs);
        }

        // GET: Repairs/Details/5
        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRepair(int id)
        {
            if (id == 0 )
            {
                return NotFound();
            }

            var repair = await _context.Repairs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (repair == null)
            {
                return NotFound();
            }

            return Ok(repair);
        }

        // GET: Repairs/Create
        public IActionResult Create()
        {
            return Ok();
        }

        // POST: Repairs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,Price,Address,Description,Days,Area,imageUrl")] Repairs repairs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(repairs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(GetRepairs));
            }
            return Ok(repairs);
        }

        // GET: Repairs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repairs = await _context.Repairs.FindAsync(id);
            if (repairs == null)
            {
                return NotFound();
            }
            return Ok(repairs);
        }

        // POST: Repairs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Price,Address,Description,Days,Area,imageUrl")] Repairs repairs)
        {
            if (id != repairs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(repairs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RepairsExists(repairs.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(GetRepairs));
            }
            return Ok(repairs);
        }

        // GET: Repairs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repairs = await _context.Repairs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (repairs == null)
            {
                return NotFound();
            }

            return Ok(repairs);
        }

        // POST: Repairs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var repairs = await _context.Repairs.FindAsync(id);
            _context.Repairs.Remove(repairs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(GetRepairs));
        }

        private bool RepairsExists(int id)
        {
            return _context.Repairs.Any(e => e.Id == id);
        }
    }
}
