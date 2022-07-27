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
    public class ГражданеController : Controller
    {
        private readonly MyDBContext _context;

        public ГражданеController(MyDBContext context)
        {
            _context = context;
        }

        // GET: Граждане
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["IDSortParm"] = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewData["SurNameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "surname_desc" : "";

            var Граждане = from s in _context.Граждане
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                Граждане = Граждане.Where(s => s.Фамилия.Contains(searchString)
                                       || s.Имя.Contains(searchString)
                                       || s.Отчество.Contains(searchString)
                                       || s.Адрес_фактического_проживания.Contains(searchString)
                                       || s.Кем_выдан_паспорт.Contains(searchString)
                                       || s.Номер_телефона.Contains(searchString)
                                       || s.Номер_СНИЛС.Contains(searchString)
                                       || s.Email.Contains(searchString));

            }
            switch (sortOrder)
            {
                case "id_desc":
                    Граждане = Граждане.OrderByDescending(s => s.ID_гражданина);
                    break;
                case "surname_desc":
                    Граждане = Граждане.OrderBy(s => s.Фамилия);
                    break;
                default:
                    Граждане = Граждане.OrderBy(s => s.Фамилия);
                    break;
            }
            return View(await Граждане.ToListAsync());
        }

        // GET: Граждане/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var граждане = await _context.Граждане
                .FirstOrDefaultAsync(m => m.ID_гражданина == id);
            if (граждане == null)
            {
                return NotFound();
            }

            return View(граждане);
        }

        // GET: Граждане/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Граждане/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_гражданина,Фамилия,Имя,Отчество,Адрес_фактического_проживания,Дата_рождения,Серия_паспорта,Номер_паспорта,Дата_выдачи_паспорта,Кем_выдан_паспорт,Номер_телефона,Номер_СНИЛС,Email")] Граждане граждане)
        {
            if (ModelState.IsValid)
            {
                _context.Add(граждане);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(граждане);
        }

        // GET: Граждане/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var граждане = await _context.Граждане.FindAsync(id);
            if (граждане == null)
            {
                return NotFound();
            }
            return View(граждане);
        }

        // POST: Граждане/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_гражданина,Фамилия,Имя,Отчество,Адрес_фактического_проживания,Дата_рождения,Серия_паспорта,Номер_паспорта,Дата_выдачи_паспорта,Кем_выдан_паспорт,Номер_телефона,Номер_СНИЛС,Email")] Граждане граждане)
        {
            if (id != граждане.ID_гражданина)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(граждане);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ГражданеExists(граждане.ID_гражданина))
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
            return View(граждане);
        }

        // GET: Граждане/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var граждане = await _context.Граждане
                .FirstOrDefaultAsync(m => m.ID_гражданина == id);
            if (граждане == null)
            {
                return NotFound();
            }

            return View(граждане);
        }

        // POST: Граждане/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var граждане = await _context.Граждане.FindAsync(id);
            _context.Граждане.Remove(граждане);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        private bool ГражданеExists(int id)
        {
            return _context.Граждане.Any(e => e.ID_гражданина == id);
        }
    }
}
