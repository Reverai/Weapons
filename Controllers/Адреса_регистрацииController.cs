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
    public class Адреса_регистрацииController : Controller
    {
        private readonly MyDBContext _context;

        public Адреса_регистрацииController(MyDBContext context)
        {
            _context = context;
        }

        // GET: Адреса_регистрации
        public async Task<IActionResult> Index(string searchString, string sortOrder)
        {
            ViewData["IDSortParm"] = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";

            var Адреса_регистрации = from s in _context.Адреса_регистрации
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                Адреса_регистрации = Адреса_регистрации.Where(s => s.ID_гражданина.ToString().Contains(searchString));

            }

            switch (sortOrder)
            {
                case "id_desc":
                    Адреса_регистрации = Адреса_регистрации.OrderByDescending(s => s.ID_гражданина);
                    break;
                default:
                    Адреса_регистрации = Адреса_регистрации.OrderByDescending(s => s.ID_гражданина);
                    break;
            }
            return View(await Адреса_регистрации.ToListAsync());
        }

        // GET: Адреса_регистрации/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var адреса_регистрации = await _context.Адреса_регистрации
                .FirstOrDefaultAsync(m => m.Код_адреса == id);
            if (адреса_регистрации == null)
            {
                return NotFound();
            }

            return View(адреса_регистрации);
        }

        // GET: Адреса_регистрации/Create
        public IActionResult Create()
        {
            SelectList граждане = new SelectList(_context.Граждане, "ID_гражданина", "Фамилия", "Отчество", "Имя");
            ViewBag.Граждане = граждане;
            return View();
        }

        // POST: Адреса_регистрации/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Код_адреса,Адрес,ID_гражданина")] Адреса_регистрации адреса_регистрации)
        {
            if (ModelState.IsValid)
            {
                _context.Add(адреса_регистрации);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(адреса_регистрации);
        }

        // GET: Адреса_регистрации/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var адреса_регистрации = await _context.Адреса_регистрации.FindAsync(id);
            if (адреса_регистрации == null)
            {
                return NotFound();
            }
            return View(адреса_регистрации);
        }

        // POST: Адреса_регистрации/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Код_адреса,Адрес,ID_гражданина")] Адреса_регистрации адреса_регистрации)
        {
            if (id != адреса_регистрации.Код_адреса)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(адреса_регистрации);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Адреса_регистрацииExists(адреса_регистрации.Код_адреса))
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
            return View(адреса_регистрации);
        }

        // GET: Адреса_регистрации/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var адреса_регистрации = await _context.Адреса_регистрации
                .FirstOrDefaultAsync(m => m.Код_адреса == id);
            if (адреса_регистрации == null)
            {
                return NotFound();
            }

            return View(адреса_регистрации);
        }

        // POST: Адреса_регистрации/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var адреса_регистрации = await _context.Адреса_регистрации.FindAsync(id);
            _context.Адреса_регистрации.Remove(адреса_регистрации);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Адреса_регистрацииExists(int id)
        {
            return _context.Адреса_регистрации.Any(e => e.Код_адреса == id);
        }
    }
}
