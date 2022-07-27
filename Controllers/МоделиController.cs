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
    public class МоделиController : Controller
    {
        private readonly MyDBContext _context;

        public МоделиController(MyDBContext context)
        {
            _context = context;
        }

        // GET: Модели
        public async Task<IActionResult> Index()
        {
            return View(await _context.Модели.ToListAsync());
        }

        // GET: Модели/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var модели = await _context.Модели
                .FirstOrDefaultAsync(m => m.Код_модели == id);
            if (модели == null)
            {
                return NotFound();
            }

            return View(модели);
        }

        // GET: Модели/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Модели/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Код_модели,Модель,Калибр,Тип")] Модели модели)
        {
            if (ModelState.IsValid)
            {
                _context.Add(модели);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(модели);
        }

        // GET: Модели/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var модели = await _context.Модели.FindAsync(id);
            if (модели == null)
            {
                return NotFound();
            }
            return View(модели);
        }

        // POST: Модели/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Код_модели,Модель,Калибр,Тип")] Модели модели)
        {
            if (id != модели.Код_модели)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(модели);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!МоделиExists(модели.Код_модели))
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
            return View(модели);
        }

        // GET: Модели/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var модели = await _context.Модели
                .FirstOrDefaultAsync(m => m.Код_модели == id);
            if (модели == null)
            {
                return NotFound();
            }

            return View(модели);
        }

        // POST: Модели/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var модели = await _context.Модели.FindAsync(id);
            _context.Модели.Remove(модели);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool МоделиExists(int id)
        {
            return _context.Модели.Any(e => e.Код_модели == id);
        }
    }
}
