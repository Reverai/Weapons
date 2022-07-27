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
    public class Медицинские_заключенияController : Controller
    {
        private readonly MyDBContext _context;

        public Медицинские_заключенияController(MyDBContext context)
        {
            _context = context;
        }

        // GET: Медицинские_заключения
        public async Task<IActionResult> Index(string searchString, string sortOrder)
        {

            ViewData["IDSortParm"] = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewData["SurNameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "surname_desc" : "";
            ViewData["DataSortParm"] = String.IsNullOrEmpty(sortOrder) ? "data_desc" : "";

            var Медицинские_заключения = from s in _context.Медицинские_заключения
                                         select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                Медицинские_заключения = Медицинские_заключения.Where(s => s.ID_гражданина.ToString().Contains(searchString));

            }
            if (!String.IsNullOrEmpty(searchString))
            {
                Медицинские_заключения = Медицинские_заключения.Where(s => s.ID_гражданина.ToString().Contains(searchString)
                                       || s.Фамилия_врача.Contains(searchString)
                                       || s.Дата_заключения.ToString().Contains(searchString));

            }
            switch (sortOrder)
            {
                case "id_desc":
                    Медицинские_заключения = Медицинские_заключения.OrderByDescending(s => s.ID_гражданина);
                    break;
                case "surname_desc":
                    Медицинские_заключения = Медицинские_заключения.OrderBy(s => s.Фамилия_врача);
                    break;
                case "data_desc":
                    Медицинские_заключения = Медицинские_заключения.OrderBy(s => s.Дата_заключения);
                    break;
                default:
                    Медицинские_заключения = Медицинские_заключения.OrderBy(s => s.ID_гражданина);
                    break;
            }
            return View(await Медицинские_заключения.ToListAsync());
        }

        // GET: Медицинские_заключения/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var медицинские_заключения = await _context.Медицинские_заключения
                .FirstOrDefaultAsync(m => m.Номер_медицинского_заключения == id);
            if (медицинские_заключения == null)
            {
                return NotFound();
            }

            return View(медицинские_заключения);
        }

        // GET: Медицинские_заключения/Create
        public IActionResult Create()
        {
            SelectList граждане = new SelectList(_context.Граждане, "ID_гражданина", "Фамилия", "Имя");
            ViewBag.Граждане = граждане;
            SelectList организации = new SelectList(_context.Медицинские_организации, "ID_организации", "Наименование_организации");
            ViewBag.Медицинские_организации = организации;
            return View();
        }

        // POST: Медицинские_заключения/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Номер_медицинского_заключения,ID_гражданина,Наличие_противопоказаний_к_владению_оружием,Фамилия_врача,Имя_врача,Отчество_врача,Дата_заключения,Срок_истечения,ID_организации")] Медицинские_заключения медицинские_заключения)
        {
            if (ModelState.IsValid)
            {
                _context.Add(медицинские_заключения);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(медицинские_заключения);
        }

        // GET: Медицинские_заключения/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var медицинские_заключения = await _context.Медицинские_заключения.FindAsync(id);
            if (медицинские_заключения == null)
            {
                return NotFound();
            }
            return View(медицинские_заключения);
        }

        // POST: Медицинские_заключения/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Номер_медицинского_заключения,ID_гражданина,Наличие_противопоказаний_к_владению_оружием,Фамилия_врача,Имя_врача,Отчество_врача,Дата_заключения,Срок_истечения,ID_организации")] Медицинские_заключения медицинские_заключения)
        {
            if (id != медицинские_заключения.Номер_медицинского_заключения)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(медицинские_заключения);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Медицинские_заключенияExists(медицинские_заключения.Номер_медицинского_заключения))
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
            return View(медицинские_заключения);
        }

        // GET: Медицинские_заключения/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var медицинские_заключения = await _context.Медицинские_заключения
                .FirstOrDefaultAsync(m => m.Номер_медицинского_заключения == id);
            if (медицинские_заключения == null)
            {
                return NotFound();
            }

            return View(медицинские_заключения);
        }

        // POST: Медицинские_заключения/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var медицинские_заключения = await _context.Медицинские_заключения.FindAsync(id);
            _context.Медицинские_заключения.Remove(медицинские_заключения);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Медицинские_заключенияExists(int id)
        {
            return _context.Медицинские_заключения.Any(e => e.Номер_медицинского_заключения == id);
        }
    }
}
