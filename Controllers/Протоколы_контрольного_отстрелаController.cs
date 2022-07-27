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
    public class Протоколы_контрольного_отстрелаController : Controller
    {
        private readonly MyDBContext _context;

        public Протоколы_контрольного_отстрелаController(MyDBContext context)
        {
            _context = context;
        }

        // GET: Протоколы_контрольного_отстрела
        public async Task<IActionResult> Index()
        {
            return View(await _context.Протоколы_контрольного_отстрела.ToListAsync());
        }

        // GET: Протоколы_контрольного_отстрела/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var протоколы_контрольного_отстрела = await _context.Протоколы_контрольного_отстрела
                .FirstOrDefaultAsync(m => m.Номер_протокола_контрольного_отстрела == id);
            if (протоколы_контрольного_отстрела == null)
            {
                return NotFound();
            }

            return View(протоколы_контрольного_отстрела);
        }

        // GET: Протоколы_контрольного_отстрела/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Протоколы_контрольного_отстрела/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Номер_протокола_контрольного_отстрела,Номер_лицензии_на_приобретение_оружия,Номер_воинской_части_или_наименование_организации,Дата_и_время_отстрела")] Протоколы_контрольного_отстрела протоколы_контрольного_отстрела)
        {
            if (ModelState.IsValid)
            {
                _context.Add(протоколы_контрольного_отстрела);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(протоколы_контрольного_отстрела);
        }

        // GET: Протоколы_контрольного_отстрела/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var протоколы_контрольного_отстрела = await _context.Протоколы_контрольного_отстрела.FindAsync(id);
            if (протоколы_контрольного_отстрела == null)
            {
                return NotFound();
            }
            return View(протоколы_контрольного_отстрела);
        }

        // POST: Протоколы_контрольного_отстрела/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Номер_протокола_контрольного_отстрела,Номер_лицензии_на_приобретение_оружия,Номер_воинской_части_или_наименование_организации,Дата_и_время_отстрела")] Протоколы_контрольного_отстрела протоколы_контрольного_отстрела)
        {
            if (id != протоколы_контрольного_отстрела.Номер_протокола_контрольного_отстрела)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(протоколы_контрольного_отстрела);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Протоколы_контрольного_отстрелаExists(протоколы_контрольного_отстрела.Номер_протокола_контрольного_отстрела))
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
            return View(протоколы_контрольного_отстрела);
        }

        // GET: Протоколы_контрольного_отстрела/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var протоколы_контрольного_отстрела = await _context.Протоколы_контрольного_отстрела
                .FirstOrDefaultAsync(m => m.Номер_протокола_контрольного_отстрела == id);
            if (протоколы_контрольного_отстрела == null)
            {
                return NotFound();
            }

            return View(протоколы_контрольного_отстрела);
        }

        // POST: Протоколы_контрольного_отстрела/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var протоколы_контрольного_отстрела = await _context.Протоколы_контрольного_отстрела.FindAsync(id);
            _context.Протоколы_контрольного_отстрела.Remove(протоколы_контрольного_отстрела);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Протоколы_контрольного_отстрелаExists(int id)
        {
            return _context.Протоколы_контрольного_отстрела.Any(e => e.Номер_протокола_контрольного_отстрела == id);
        }
    }
}
