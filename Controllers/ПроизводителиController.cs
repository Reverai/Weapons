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
    public class ПроизводителиController : Controller
    {
        private readonly MyDBContext _context;

        public ПроизводителиController(MyDBContext context)
        {
            _context = context;
        }

        // GET: Производители
        public async Task<IActionResult> Index()
        {
            return View(await _context.Производители.ToListAsync());
        }

        // GET: Производители/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var производители = await _context.Производители
                .FirstOrDefaultAsync(m => m.Код_производителя == id);
            if (производители == null)
            {
                return NotFound();
            }

            return View(производители);
        }

        // GET: Производители/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Производители/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Код_производителя,Наименование_производителя")] Производители производители)
        {
            if (ModelState.IsValid)
            {
                _context.Add(производители);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(производители);
        }

        // GET: Производители/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var производители = await _context.Производители.FindAsync(id);
            if (производители == null)
            {
                return NotFound();
            }
            return View(производители);
        }

        // POST: Производители/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Код_производителя,Наименование_производителя")] Производители производители)
        {
            if (id != производители.Код_производителя)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(производители);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ПроизводителиExists(производители.Код_производителя))
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
            return View(производители);
        }

        // GET: Производители/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var производители = await _context.Производители
                .FirstOrDefaultAsync(m => m.Код_производителя == id);
            if (производители == null)
            {
                return NotFound();
            }

            return View(производители);
        }

        // POST: Производители/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var производители = await _context.Производители.FindAsync(id);
            _context.Производители.Remove(производители);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ПроизводителиExists(int id)
        {
            return _context.Производители.Any(e => e.Код_производителя == id);
        }
    }
}
