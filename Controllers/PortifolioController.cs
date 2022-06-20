using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class PortifolioController : Controller
    {
        private readonly WebContext _context;

        public PortifolioController(WebContext context)
        {
            _context = context;
        }

        // GET: Portifolio
        public async Task<IActionResult> Index()
        {
              return _context.Portifolio != null ? 
                          View(await _context.Portifolio.ToListAsync()) :
                          Problem("Entity set 'WebContext.Portifolio'  is null.");
        }

        // GET: Portifolio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Portifolio == null)
            {
                return NotFound();
            }

            var portifolio = await _context.Portifolio
                .FirstOrDefaultAsync(m => m.Id == id);
            if (portifolio == null)
            {
                return NotFound();
            }

            return View(portifolio);
        }

        // GET: Portifolio/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Portifolio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descrition,Title,LinkProject")] Portifolio portifolio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(portifolio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(portifolio);
        }

        // GET: Portifolio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Portifolio == null)
            {
                return NotFound();
            }

            var portifolio = await _context.Portifolio.FindAsync(id);
            if (portifolio == null)
            {
                return NotFound();
            }
            return View(portifolio);
        }

        // POST: Portifolio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descrition,Title,LinkProject")] Portifolio portifolio)
        {
            if (id != portifolio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(portifolio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PortifolioExists(portifolio.Id))
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
            return View(portifolio);
        }

        // GET: Portifolio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Portifolio == null)
            {
                return NotFound();
            }

            var portifolio = await _context.Portifolio
                .FirstOrDefaultAsync(m => m.Id == id);
            if (portifolio == null)
            {
                return NotFound();
            }

            return View(portifolio);
        }

        // POST: Portifolio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Portifolio == null)
            {
                return Problem("Entity set 'WebContext.Portifolio'  is null.");
            }
            var portifolio = await _context.Portifolio.FindAsync(id);
            if (portifolio != null)
            {
                _context.Portifolio.Remove(portifolio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PortifolioExists(int id)
        {
          return (_context.Portifolio?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
