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
    public class Отчёты_о_правонарушенияхController : Controller
    {
        private readonly MyDBContext _context;

        public Отчёты_о_правонарушенияхController(MyDBContext context)
        {
            _context = context;
        }

        // GET: Отчёты_о_правонарушениях
        public async Task<IActionResult> Index()
        {
            return View(await _context.Отчёты_о_правонарушениях.ToListAsync());
        }

        // GET: Отчёты_о_правонарушениях/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var отчёты_о_правонарушениях = await _context.Отчёты_о_правонарушениях
                .FirstOrDefaultAsync(m => m.Номер_отчёта == id);
            if (отчёты_о_правонарушениях == null)
            {
                return NotFound();
            }

            return View(отчёты_о_правонарушениях);
        }

        // GET: Отчёты_о_правонарушениях/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Отчёты_о_правонарушениях/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Номер_отчёта,Вид_правонарушения,Дата_правонарушения")] Отчёты_о_правонарушениях отчёты_о_правонарушениях)
        {
            if (ModelState.IsValid)
            {
                _context.Add(отчёты_о_правонарушениях);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(отчёты_о_правонарушениях);
        }

        // GET: Отчёты_о_правонарушениях/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var отчёты_о_правонарушениях = await _context.Отчёты_о_правонарушениях.FindAsync(id);
            if (отчёты_о_правонарушениях == null)
            {
                return NotFound();
            }
            return View(отчёты_о_правонарушениях);
        }

        // POST: Отчёты_о_правонарушениях/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Номер_отчёта,Вид_правонарушения,Дата_правонарушения")] Отчёты_о_правонарушениях отчёты_о_правонарушениях)
        {
            if (id != отчёты_о_правонарушениях.Номер_отчёта)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(отчёты_о_правонарушениях);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Отчёты_о_правонарушенияхExists(отчёты_о_правонарушениях.Номер_отчёта))
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
            return View(отчёты_о_правонарушениях);
        }

        // GET: Отчёты_о_правонарушениях/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var отчёты_о_правонарушениях = await _context.Отчёты_о_правонарушениях
                .FirstOrDefaultAsync(m => m.Номер_отчёта == id);
            if (отчёты_о_правонарушениях == null)
            {
                return NotFound();
            }

            return View(отчёты_о_правонарушениях);
        }

        // POST: Отчёты_о_правонарушениях/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var отчёты_о_правонарушениях = await _context.Отчёты_о_правонарушениях.FindAsync(id);
            _context.Отчёты_о_правонарушениях.Remove(отчёты_о_правонарушениях);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Отчёты_о_правонарушенияхExists(int id)
        {
            return _context.Отчёты_о_правонарушениях.Any(e => e.Номер_отчёта == id);
        }
    }
}
