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
    public class ОружиеController : Controller
    {
        private readonly MyDBContext _context;

        public ОружиеController(MyDBContext context)
        {
            _context = context;
        }

        // GET: Оружие
        public async Task<IActionResult> Index(string searchString, string sortOrder)
        {
            ViewData["DataSortParm"] = String.IsNullOrEmpty(sortOrder) ? "data_desc" : "";

            var Оружие = from s in _context.Оружие
                         select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                Оружие = Оружие.Where(s => s.Серийный_номер.Contains(searchString));

            }
            if (!String.IsNullOrEmpty(searchString))
            {
                Оружие = Оружие.Where(s => s.Год_выпуска.ToString().Contains(searchString));

            }
            switch (sortOrder)
            {

                case "data_desc":
                    Оружие = Оружие.OrderBy(s => s.Год_выпуска);
                    break;
                default:
                    Оружие = Оружие.OrderBy(s => s.Год_выпуска);
                    break;
            }

            return View(await Оружие.ToListAsync());
        }

        // GET: Оружие/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var оружие = await _context.Оружие
                .FirstOrDefaultAsync(m => m.Номер_лицензии_на_приобретение_оружия == id);
            if (оружие == null)
            {
                return NotFound();
            }

            return View(оружие);
        }

        // GET: Оружие/Create
        public IActionResult Create()
        {
            SelectList модели = new SelectList(_context.Модели, "Код_модели", "Модель", "Калибр", "Тип");
            ViewBag.Модели = модели;
            SelectList производители = new SelectList(_context.Производители, "Код_производителя", "Наименование_производителя");
            ViewBag.Производители = производители;
            return View();
        }

        // POST: Оружие/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Номер_лицензии_на_приобретение_оружия,Серийный_номер,Код_модели,Серия,Год_выпуска,Код_производителя")] Оружие оружие)
        {
            if (ModelState.IsValid)
            {
                _context.Add(оружие);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(оружие);
        }

        // GET: Оружие/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var оружие = await _context.Оружие.FindAsync(id);
            if (оружие == null)
            {
                return NotFound();
            }
            return View(оружие);
        }

        // POST: Оружие/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Номер_лицензии_на_приобретение_оружия,Серийный_номер,Код_модели,Серия,Год_выпуска,Код_производителя")] Оружие оружие)
        {
            if (id != оружие.Номер_лицензии_на_приобретение_оружия)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(оружие);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ОружиеExists(оружие.Номер_лицензии_на_приобретение_оружия))
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
            return View(оружие);
        }

        // GET: Оружие/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var оружие = await _context.Оружие
                .FirstOrDefaultAsync(m => m.Номер_лицензии_на_приобретение_оружия == id);
            if (оружие == null)
            {
                return NotFound();
            }

            return View(оружие);
        }

        // POST: Оружие/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var оружие = await _context.Оружие.FindAsync(id);
            _context.Оружие.Remove(оружие);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ОружиеExists(int id)
        {
            return _context.Оружие.Any(e => e.Номер_лицензии_на_приобретение_оружия == id);
        }
    }
}
