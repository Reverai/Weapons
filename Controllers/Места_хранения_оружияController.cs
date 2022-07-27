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
    public class Места_хранения_оружияController : Controller
    {
        private readonly MyDBContext _context;

        public Места_хранения_оружияController(MyDBContext context)
        {
            _context = context;
        }

        // GET: Места_хранения_оружия
        public async Task<IActionResult> Index()
        {
            return View(await _context.Места_хранения_оружия.ToListAsync());
        }

        // GET: Места_хранения_оружия/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var места_хранения_оружия = await _context.Места_хранения_оружия
                .FirstOrDefaultAsync(m => m.ID_места_хранения == id);
            if (места_хранения_оружия == null)
            {
                return NotFound();
            }

            return View(места_хранения_оружия);
        }

        // GET: Места_хранения_оружия/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Места_хранения_оружия/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_места_хранения,Район,Дом,Улица,Квартира,Код_города")] Места_хранения_оружия места_хранения_оружия)
        {
            if (ModelState.IsValid)
            {
                _context.Add(места_хранения_оружия);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(места_хранения_оружия);
        }

        // GET: Места_хранения_оружия/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var места_хранения_оружия = await _context.Места_хранения_оружия.FindAsync(id);
            if (места_хранения_оружия == null)
            {
                return NotFound();
            }
            return View(места_хранения_оружия);
        }

        // POST: Места_хранения_оружия/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_места_хранения,Район,Дом,Улица,Квартира,Код_города")] Места_хранения_оружия места_хранения_оружия)
        {
            if (id != места_хранения_оружия.ID_места_хранения)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(места_хранения_оружия);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Места_хранения_оружияExists(места_хранения_оружия.ID_места_хранения))
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
            return View(места_хранения_оружия);
        }

        // GET: Места_хранения_оружия/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var места_хранения_оружия = await _context.Места_хранения_оружия
                .FirstOrDefaultAsync(m => m.ID_места_хранения == id);
            if (места_хранения_оружия == null)
            {
                return NotFound();
            }

            return View(места_хранения_оружия);
        }

        // POST: Места_хранения_оружия/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var места_хранения_оружия = await _context.Места_хранения_оружия.FindAsync(id);
            _context.Места_хранения_оружия.Remove(места_хранения_оружия);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Места_хранения_оружияExists(int id)
        {
            return _context.Места_хранения_оружия.Any(e => e.ID_места_хранения == id);
        }
    }
}
