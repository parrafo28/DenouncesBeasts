using DenouncesBeasts.Frontend.Data;
using DenouncesBeasts.Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DenouncesBeasts.Frontend.Controllers
{
    public class DenounzersController : Controller
    {
        private readonly DataContext _context;

        public DenounzersController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string filter = "")
        {
            var list = await _context.Denounzers.ToListAsync();

            if (!string.IsNullOrEmpty( filter))
            {
                list = list.Where(d => d.Name.ToLower().Contains(filter.ToLower())
             || d.Lastname.ToLower().Contains(filter.ToLower())).ToList();
            }
            return View(list);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var denounce = await _context.Denounzers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (denounce == null)
            {
                return NotFound();
            }

            return View(denounce);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Denounzer denounce)
        {
            if (ModelState.IsValid)
            {
                _context.Add(denounce);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(denounce);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var denounce = await _context.Denounzers.FindAsync(id);
            if (denounce == null)
            {
                return NotFound();
            }
            return View(denounce);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Denounzer denounce)
        {
            if (id != denounce.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(denounce);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DenouncerExists(denounce.Id))
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
            return View(denounce);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = await _context.Denounzers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entity = await _context.Denounzers.FindAsync(id);
            if (entity != null)
            {
                _context.Denounzers.Remove(entity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DenouncerExists(int id)
        {
            return _context.Denounzers.Any(e => e.Id == id);
        }
    }
}
