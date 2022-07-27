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
    public class Лицензии_на_хранение_оружияController : Controller
    {
        private readonly MyDBContext _context;

        public Лицензии_на_хранение_оружияController(MyDBContext context)
        {
            _context = context;
        }

        // GET: Лицензии_на_хранение_оружия
        public async Task<IActionResult> Index(string searchString)
        {
            var Лицензии_на_хранение_оружия = from s in _context.Лицензии_на_хранение_оружия
                                              select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                Лицензии_на_хранение_оружия = Лицензии_на_хранение_оружия.Where(s => s.Номер_лицензии_на_приобретение_оружия.ToString().Contains(searchString));

            }
            return View(await _context.Лицензии_на_хранение_оружия.ToListAsync());
        }

        // GET: Лицензии_на_хранение_оружия/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var лицензии_на_хранение_оружия = await _context.Лицензии_на_хранение_оружия
                .FirstOrDefaultAsync(m => m.Номер_лицензии == id);
            if (лицензии_на_хранение_оружия == null)
            {
                return NotFound();
            }

            return View(лицензии_на_хранение_оружия);
        }

        // GET: Лицензии_на_хранение_оружия/Create
        public IActionResult Create()
        {
            SelectList места = new SelectList(_context.Места_хранения_оружия, "ID_места_хранения", "Улица", "Дом");
            ViewBag.Места_хранения_оружия = места;
            return View();
        }

        // POST: Лицензии_на_хранение_оружия/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Номер_лицензии,Номер_лицензии_на_приобретение_оружия,Дата_выдачи,Дата_окончания,Где_выдано,Кем_выдано,ID_места_хранения")] Лицензии_на_хранение_оружия лицензии_на_хранение_оружия)
        {
            if (ModelState.IsValid)
            {
                _context.Add(лицензии_на_хранение_оружия);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(лицензии_на_хранение_оружия);
        }

        // GET: Лицензии_на_хранение_оружия/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var лицензии_на_хранение_оружия = await _context.Лицензии_на_хранение_оружия.FindAsync(id);
            if (лицензии_на_хранение_оружия == null)
            {
                return NotFound();
            }
            return View(лицензии_на_хранение_оружия);
        }

        // POST: Лицензии_на_хранение_оружия/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Номер_лицензии,Номер_лицензии_на_приобретение_оружия,Дата_выдачи,Дата_окончания,Где_выдано,Кем_выдано,ID_места_хранения")] Лицензии_на_хранение_оружия лицензии_на_хранение_оружия)
        {
            if (id != лицензии_на_хранение_оружия.Номер_лицензии)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(лицензии_на_хранение_оружия);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Лицензии_на_хранение_оружияExists(лицензии_на_хранение_оружия.Номер_лицензии))
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
            return View(лицензии_на_хранение_оружия);
        }

        // GET: Лицензии_на_хранение_оружия/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var лицензии_на_хранение_оружия = await _context.Лицензии_на_хранение_оружия
                .FirstOrDefaultAsync(m => m.Номер_лицензии == id);
            if (лицензии_на_хранение_оружия == null)
            {
                return NotFound();
            }

            return View(лицензии_на_хранение_оружия);
        }

        // POST: Лицензии_на_хранение_оружия/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var лицензии_на_хранение_оружия = await _context.Лицензии_на_хранение_оружия.FindAsync(id);
            _context.Лицензии_на_хранение_оружия.Remove(лицензии_на_хранение_оружия);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Лицензии_на_хранение_оружияExists(int id)
        {
            return _context.Лицензии_на_хранение_оружия.Any(e => e.Номер_лицензии == id);
        }
    }
}
