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
    public class ЗаявленияController : Controller
    {
        private readonly MyDBContext _context;

        public ЗаявленияController(MyDBContext context)
        {
            _context = context;
        }

        // GET: Заявления
        public async Task<IActionResult> Index(string searchString)
        {
            var Заявления = from s in _context.Заявления
                            select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                Заявления = Заявления.Where(s => s.ID_гражданина.ToString().Contains(searchString));

            }
            return View(await Заявления.ToListAsync());
        }

        // GET: Заявления/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var заявления = await _context.Заявления
                .FirstOrDefaultAsync(m => m.Номер_заявления == id);
            if (заявления == null)
            {
                return NotFound();
            }

            return View(заявления);
        }

        // GET: Заявления/Create
        public IActionResult Create()
        {
            SelectList граждане = new SelectList(_context.Граждане, "ID_гражданина", "Фамилия", "Имя");
            ViewBag.Граждане = граждане;
            return View();
        }

        // POST: Заявления/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Номер_заявления,Цель_приобретения_оружия,ID_гражданина,Фото")] Заявления заявления)
        {
            if (ModelState.IsValid)
            {
                _context.Add(заявления);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(заявления);
        }

        // GET: Заявления/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var заявления = await _context.Заявления.FindAsync(id);
            if (заявления == null)
            {
                return NotFound();
            }
            return View(заявления);
        }

        // POST: Заявления/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Номер_заявления,Цель_приобретения_оружия,ID_гражданина,Фото")] Заявления заявления)
        {
            if (id != заявления.Номер_заявления)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(заявления);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ЗаявленияExists(заявления.Номер_заявления))
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
            return View(заявления);
        }

        // GET: Заявления/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var заявления = await _context.Заявления
                .FirstOrDefaultAsync(m => m.Номер_заявления == id);
            if (заявления == null)
            {
                return NotFound();
            }

            return View(заявления);
        }

        // POST: Заявления/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var заявления = await _context.Заявления.FindAsync(id);
            _context.Заявления.Remove(заявления);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ЗаявленияExists(int id)
        {
            return _context.Заявления.Any(e => e.Номер_заявления == id);
        }
    }
}
