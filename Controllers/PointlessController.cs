using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PointlessDataStorage.Models;

namespace PointlessDataStorage.Controllers
{
    
    public class PointlessController : Controller
    {
        private readonly PointlessDataStorageContext _context;

        public PointlessController(PointlessDataStorageContext context)
        {
            _context = context;
        }

        // GET: Pointless
        //Ordered from highest to lowest
        public async Task<IActionResult> Index()
        {
            //var list = await _context.UselessDataBlock.ToListAsync();
            //var sortedList = list.Sort((x, y) => x.garbageFloat.CompareTo(y.garbageFloat));
            //return View(await _context.UselessDataBlock.ToListAsync());
            var dataBlock = from d in _context.UselessDataBlock
                            select d;
            dataBlock = dataBlock.OrderByDescending(d => d.garbageFloat);
            return View(await dataBlock.AsNoTracking().ToListAsync());
        }

        // GET: Pointless/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uselessDataBlock = await _context.UselessDataBlock
                .FirstOrDefaultAsync(m => m.ID == id);
            if (uselessDataBlock == null)
            {
                return NotFound();
            }

            return View(uselessDataBlock);
        }

        // GET: Pointless/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pointless/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,name,randomDate,garbageFloat")] UselessDataBlock uselessDataBlock)
        {
            if (ModelState.IsValid)
            {
                _context.Add(uselessDataBlock);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(uselessDataBlock);
        }

        // GET: Pointless/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uselessDataBlock = await _context.UselessDataBlock.FindAsync(id);
            if (uselessDataBlock == null)
            {
                return NotFound();
            }
            return View(uselessDataBlock);
        }

        // POST: Pointless/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,name,randomDate,garbageFloat")] UselessDataBlock uselessDataBlock)
        {
            if (id != uselessDataBlock.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uselessDataBlock);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UselessDataBlockExists(uselessDataBlock.ID))
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
            return View(uselessDataBlock);
        }

        // GET: Pointless/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uselessDataBlock = await _context.UselessDataBlock
                .FirstOrDefaultAsync(m => m.ID == id);
            if (uselessDataBlock == null)
            {
                return NotFound();
            }

            return View(uselessDataBlock);
        }

        // POST: Pointless/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var uselessDataBlock = await _context.UselessDataBlock.FindAsync(id);
            _context.UselessDataBlock.Remove(uselessDataBlock);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UselessDataBlockExists(int id)
        {
            return _context.UselessDataBlock.Any(e => e.ID == id);
        }
    }
}
