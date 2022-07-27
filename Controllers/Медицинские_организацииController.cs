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
    public class Медицинские_организацииController : Controller
    {
        private readonly MyDBContext _context;

        public Медицинские_организацииController(MyDBContext context)
        {
            _context = context;
        }

        // GET: Медицинские_организации
        public async Task<IActionResult> Index(string searchString)
        {
            var Медицинские_организации = from s in _context.Медицинские_организации
                                          select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                Медицинские_организации = Медицинские_организации.Where(s => s.Наименование_организации.Contains(searchString));

            }
            return View(await Медицинские_организации.ToListAsync());
        }

        // GET: Медицинские_организации/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var медицинские_организации = await _context.Медицинские_организации
                .FirstOrDefaultAsync(m => m.ID_организации == id);
            if (медицинские_организации == null)
            {
                return NotFound();
            }

            return View(медицинские_организации);
        }

        // GET: Медицинские_организации/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Медицинские_организации/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_организации,Наименование_организации")] Медицинские_организации медицинские_организации)
        {
            if (ModelState.IsValid)
            {
                _context.Add(медицинские_организации);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(медицинские_организации);
        }

        // GET: Медицинские_организации/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var медицинские_организации = await _context.Медицинские_организации.FindAsync(id);
            if (медицинские_организации == null)
            {
                return NotFound();
            }
            return View(медицинские_организации);
        }

        // POST: Медицинские_организации/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_организации,Наименование_организации")] Медицинские_организации медицинские_организации)
        {
            if (id != медицинские_организации.ID_организации)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(медицинские_организации);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Медицинские_организацииExists(медицинские_организации.ID_организации))
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
            return View(медицинские_организации);
        }

        // GET: Медицинские_организации/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var медицинские_организации = await _context.Медицинские_организации
                .FirstOrDefaultAsync(m => m.ID_организации == id);
            if (медицинские_организации == null)
            {
                return NotFound();
            }

            return View(медицинские_организации);
        }

        // POST: Медицинские_организации/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var медицинские_организации = await _context.Медицинские_организации.FindAsync(id);
            _context.Медицинские_организации.Remove(медицинские_организации);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Медицинские_организацииExists(int id)
        {
            return _context.Медицинские_организации.Any(e => e.ID_организации == id);
        }
    }
}
