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
    public class Лицензии_на_приобретение_оружияController : Controller
    {
        private readonly MyDBContext _context;

        public Лицензии_на_приобретение_оружияController(MyDBContext context)
        {
            _context = context;
        }

        // GET: Лицензии_на_приобретение_оружия
        public async Task<IActionResult> Index(string searchString, string sortOrder)
        {
            ViewData["IDSortParm"] = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewData["Data1SortParm"] = String.IsNullOrEmpty(sortOrder) ? "data1_desc" : "data";
            ViewData["Data2SortParm"] = String.IsNullOrEmpty(sortOrder) ? "data2_desc" : "";
            ViewData["Data3SortParm"] = String.IsNullOrEmpty(sortOrder) ? "data3_desc" : "";

            var Лицензии_на_приобретение_оружия = from s in _context.Лицензии_на_приобретение_оружия
                                                  select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                Лицензии_на_приобретение_оружия = Лицензии_на_приобретение_оружия.Where(s => s.ID_гражданина.ToString().Contains(searchString));

            }
            if (!String.IsNullOrEmpty(searchString))
            {
                Лицензии_на_приобретение_оружия = Лицензии_на_приобретение_оружия.Where(s => s.ID_гражданина.ToString().Contains(searchString)
                                       || s.Дата_выдачи.ToString().Contains(searchString)
                                       || s.Дата_истечения.ToString().Contains(searchString)
                                       || s.Дата_приобретения.ToString().Contains(searchString));

            }
            switch (sortOrder)
            {
                case "id_desc":
                    Лицензии_на_приобретение_оружия = Лицензии_на_приобретение_оружия.OrderByDescending(s => s.ID_гражданина);
                    break;
                case "data1_desc":
                    Лицензии_на_приобретение_оружия = Лицензии_на_приобретение_оружия.OrderBy(s => s.Дата_выдачи);
                    break;
                case "data2_desc":
                    Лицензии_на_приобретение_оружия = Лицензии_на_приобретение_оружия.OrderBy(s => s.Дата_истечения);
                    break;
                case "data3_desc":
                    Лицензии_на_приобретение_оружия = Лицензии_на_приобретение_оружия.OrderBy(s => s.Дата_приобретения);
                    break;
                default:
                    Лицензии_на_приобретение_оружия = Лицензии_на_приобретение_оружия.OrderBy(s => s.ID_гражданина);
                    break;
            }

            return View(await Лицензии_на_приобретение_оружия.ToListAsync());
        }

        // GET: Лицензии_на_приобретение_оружия/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var лицензии_на_приобретение_оружия = await _context.Лицензии_на_приобретение_оружия
                .FirstOrDefaultAsync(m => m.Номер_лицензии_на_приобретение_оружия == id);
            if (лицензии_на_приобретение_оружия == null)
            {
                return NotFound();
            }

            return View(лицензии_на_приобретение_оружия);
        }

        // GET: Лицензии_на_приобретение_оружия/Create
        public IActionResult Create()
        {
            SelectList граждане = new SelectList(_context.Граждане, "ID_гражданина", "Фамилия", "Имя");
            ViewBag.Граждане = граждане;
            return View();
        }

        // POST: Лицензии_на_приобретение_оружия/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Номер_лицензии_на_приобретение_оружия,ID_гражданина,Наименование_организации,Дата_выдачи,Дата_истечения,Дата_приобретения")] Лицензии_на_приобретение_оружия лицензии_на_приобретение_оружия)
        {
            if (ModelState.IsValid)
            {
                _context.Add(лицензии_на_приобретение_оружия);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(лицензии_на_приобретение_оружия);
        }

        // GET: Лицензии_на_приобретение_оружия/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var лицензии_на_приобретение_оружия = await _context.Лицензии_на_приобретение_оружия.FindAsync(id);
            if (лицензии_на_приобретение_оружия == null)
            {
                return NotFound();
            }
            return View(лицензии_на_приобретение_оружия);
        }

        // POST: Лицензии_на_приобретение_оружия/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Номер_лицензии_на_приобретение_оружия,ID_гражданина,Наименование_организации,Дата_выдачи,Дата_истечения,Дата_приобретения")] Лицензии_на_приобретение_оружия лицензии_на_приобретение_оружия)
        {
            if (id != лицензии_на_приобретение_оружия.Номер_лицензии_на_приобретение_оружия)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(лицензии_на_приобретение_оружия);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Лицензии_на_приобретение_оружияExists(лицензии_на_приобретение_оружия.Номер_лицензии_на_приобретение_оружия))
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
            return View(лицензии_на_приобретение_оружия);
        }

        // GET: Лицензии_на_приобретение_оружия/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var лицензии_на_приобретение_оружия = await _context.Лицензии_на_приобретение_оружия
                .FirstOrDefaultAsync(m => m.Номер_лицензии_на_приобретение_оружия == id);
            if (лицензии_на_приобретение_оружия == null)
            {
                return NotFound();
            }

            return View(лицензии_на_приобретение_оружия);
        }

        // POST: Лицензии_на_приобретение_оружия/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var лицензии_на_приобретение_оружия = await _context.Лицензии_на_приобретение_оружия.FindAsync(id);
            _context.Лицензии_на_приобретение_оружия.Remove(лицензии_на_приобретение_оружия);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Лицензии_на_приобретение_оружияExists(int id)
        {
            return _context.Лицензии_на_приобретение_оружия.Any(e => e.Номер_лицензии_на_приобретение_оружия == id);
        }
    }
}
