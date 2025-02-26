using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore; 
using DenouncesBeasts.Frontend.Models;
using DenouncesBeasts.Persistence;
using DenouncesBeasts.Domain.Entities;

namespace DenouncesBeasts.Frontend.Controllers
{
    public class DenouncesController : Controller
    {
        private readonly DataContext _context;

        public DenouncesController(DataContext context)
        {
            _context = context;
        }
         
        public async Task<IActionResult> Index()
        {
            return View(await _context.Denounces.ToListAsync());
        }
         
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var denounce = await _context.Denounces
                .FirstOrDefaultAsync(m => m.Id == id);
            if (denounce == null)
            {
                return NotFound();
            }

            return View(denounce);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var denounzers = await _context.Denounzers
                .Select(d => new { d.Id, d.Name })
                .ToListAsync();

           
            DenounceViewModel model = new DenounceViewModel();
            model.DenounzersSelectList = new SelectList(denounzers, "Id", "Name");
            return View (model);  
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DenounceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var denounce = new Denounce();
                denounce.DenounzerId = model.DenounzerId;
                denounce.Longitude = model.Longitude;
                denounce.Latitude = model.Latitude;
                denounce.Status = model.Status;
                denounce.Tittle = model.Tittle;
                denounce.Description = model.Description;
                denounce.PictureUrl = model.PictureUrl;
                 
                _context.Denounces.Add(denounce);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
         
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var denounce = await _context.Denounces.FindAsync(id);
            if (denounce == null)
            {
                return NotFound();
            }
            return View(denounce);
        }
 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  Denounce denounce)
        {
            if (id != denounce.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Denounces.Update(denounce);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DenounceExists(denounce.Id))
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

            var denounce = await _context.Denounces
                .FirstOrDefaultAsync(m => m.Id == id);
            if (denounce == null)
            {
                return NotFound();
            }

            return View(denounce);
        }
         
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var denounce = await _context.Denounces.FindAsync(id);
            if (denounce != null)
            {
                _context.Denounces.Remove(denounce);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DenounceExists(int id)
        {
            return _context.Denounces.Any(e => e.Id == id);
        }
    }
}
