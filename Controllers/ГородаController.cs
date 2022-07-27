using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyDB.Data;
using Weapons.Models;

namespace Weapons.Controllers
{
    public class ГородаController : Controller
    {
        private readonly MyDBContext _context;

        public ГородаController(MyDBContext context)
        {
            _context = context;
        }

        // GET: Города
        public async Task<IActionResult> Index()
        {
            return View(await _context.Города.ToListAsync());
        }

        // GET: Города/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var города = await _context.Города
                .FirstOrDefaultAsync(m => m.Город == id);
            if (города == null)
            {
                return NotFound();
            }

            return View(города);
        }

        // GET: Города/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Города/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Город,Область")] Города города)
        {
            if (ModelState.IsValid)
            {
                _context.Add(города);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(города);
        }

        // GET: Города/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var города = await _context.Города.FindAsync(id);
            if (города == null)
            {
                return NotFound();
            }
            return View(города);
        }

        // POST: Города/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Город,Область")] Города города)
        {
            if (id != города.Город)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(города);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ГородаExists(города.Город))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(города);
        }

        // GET: Города/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var города = await _context.Города
                .FirstOrDefaultAsync(m => m.Город == id);
            if (города == null)
            {
                return NotFound();
            }

            return View(города);
        }

        // POST: Города/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var города = await _context.Города.FindAsync(id);
            _context.Города.Remove(города);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ГородаExists(string id)
        {
            return _context.Города.Any(e => e.Город == id);
        }
    }
}
