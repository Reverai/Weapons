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
    public class Запросы_в_ГУ_МВДController : Controller
    {
        private readonly MyDBContext _context;

        public Запросы_в_ГУ_МВДController(MyDBContext context)
        {
            _context = context;
        }

        // GET: Запросы_в_ГУ_МВД
        public async Task<IActionResult> Index(string searchString)
        {
            var Запросы_в_ГУ_МВД = from s in _context.Запросы_в_ГУ_МВД
                                   select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                Запросы_в_ГУ_МВД = Запросы_в_ГУ_МВД.Where(s => s.ID_гражданина.ToString().Contains(searchString));

            }
            return View(await Запросы_в_ГУ_МВД.ToListAsync());
        }

        // GET: Запросы_в_ГУ_МВД/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var запросы_в_ГУ_МВД = await _context.Запросы_в_ГУ_МВД
                .FirstOrDefaultAsync(m => m.Номер_запроса_в_ГУ_МВД == id);
            if (запросы_в_ГУ_МВД == null)
            {
                return NotFound();
            }

            return View(запросы_в_ГУ_МВД);
        }

        // GET: Запросы_в_ГУ_МВД/Create
        public IActionResult Create()
        {
            SelectList граждане = new SelectList(_context.Граждане, "ID_гражданина", "Фамилия", "Имя");
            ViewBag.Граждане = граждане;
            return View();
        }

        // POST: Запросы_в_ГУ_МВД/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Номер_запроса_в_ГУ_МВД,Дата_запроса,Номер_отчёта,ID_гражданина")] Запросы_в_ГУ_МВД запросы_в_ГУ_МВД)
        {
            if (ModelState.IsValid)
            {
                _context.Add(запросы_в_ГУ_МВД);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(запросы_в_ГУ_МВД);
        }

        // GET: Запросы_в_ГУ_МВД/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var запросы_в_ГУ_МВД = await _context.Запросы_в_ГУ_МВД.FindAsync(id);
            if (запросы_в_ГУ_МВД == null)
            {
                return NotFound();
            }
            return View(запросы_в_ГУ_МВД);
        }

        // POST: Запросы_в_ГУ_МВД/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Номер_запроса_в_ГУ_МВД,Дата_запроса,Номер_отчёта,ID_гражданина")] Запросы_в_ГУ_МВД запросы_в_ГУ_МВД)
        {
            if (id != запросы_в_ГУ_МВД.Номер_запроса_в_ГУ_МВД)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(запросы_в_ГУ_МВД);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Запросы_в_ГУ_МВДExists(запросы_в_ГУ_МВД.Номер_запроса_в_ГУ_МВД))
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
            return View(запросы_в_ГУ_МВД);
        }

        // GET: Запросы_в_ГУ_МВД/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var запросы_в_ГУ_МВД = await _context.Запросы_в_ГУ_МВД
                .FirstOrDefaultAsync(m => m.Номер_запроса_в_ГУ_МВД == id);
            if (запросы_в_ГУ_МВД == null)
            {
                return NotFound();
            }

            return View(запросы_в_ГУ_МВД);
        }

        // POST: Запросы_в_ГУ_МВД/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var запросы_в_ГУ_МВД = await _context.Запросы_в_ГУ_МВД.FindAsync(id);
            _context.Запросы_в_ГУ_МВД.Remove(запросы_в_ГУ_МВД);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Запросы_в_ГУ_МВДExists(int id)
        {
            return _context.Запросы_в_ГУ_МВД.Any(e => e.Номер_запроса_в_ГУ_МВД == id);
        }
    }
}
