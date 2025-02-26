using DenouncesBeasts.Domain.Entities;
using DenouncesBeasts.Frontend.Models;
using DenouncesBeasts.Persistence;
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

        //public async Task<JsonResult> GetAll(string filter = "")
        //{
        //    var list = await _context.Denounzers.ToListAsync();

        //    if (!string.IsNullOrEmpty(filter))
        //    {
        //        list = list.Where(d => d.Name.ToLower().Contains(filter.ToLower())
        //                             || d.Lastname.ToLower().Contains(filter.ToLower()))
        //                   .ToList();
        //    }
        //    return Json(list);
        //}

        //public async Task<JsonResult> Get(int id)
        //{
        //    var denounce = await _context.Denounzers.FindAsync(id);
        //    if (denounce == null)
        //    {
        //        return Json(new { success = false, message = "Not found" });
        //    }
        //    return Json(denounce);
        //}

        public IActionResult Index( )
        { 
            return View();
        }

        public IActionResult Details(int id)
        {  
            return View(new Denounzer { Id = id });
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<JsonResult> Create([FromBody] Denounzer denounce)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Json(new { success = false, message = "Invalid data" });
        //    }

        //    _context.Add(denounce);
        //    await _context.SaveChangesAsync();
        //    return Json(new { success = true, message = "Created successfully!" });
        //}

        public IActionResult Edit(int id)
        { 
            return View(new Denounzer { Id = id });
        }
         
        public IActionResult Delete(int id)
        { 

            return View(new Denounzer { Id = id });
        }
 
    }
}
