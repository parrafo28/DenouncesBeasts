using DenouncesBeasts.Domain.Entities;
using DenouncesBeasts.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DenouncesBeasts.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DenounzersController : ControllerBase
    {
        private readonly DataContext _context;

        public DenounzersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(string filter = "")
        {
            var list = await _context.Denounzers.ToListAsync();

            if (!string.IsNullOrEmpty(filter))
            {
                list = list.Where(d => d.Name.ToLower().Contains(filter.ToLower())
                                     || d.Lastname.ToLower().Contains(filter.ToLower()))
                           .ToList();
            }
            var response = new List<DenounzerDto>();
            foreach (var item in list)
            { 
                response.Add(new DenounzerDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    Lastname = item.Lastname,
                    PhoneNumber = item.PhoneNumber
                });
            }
            return Ok(response);
        }

        [HttpGet("Get/{id}")] 
        public async Task<IActionResult> Get(int id)
        {
            var denounce = await _context.Denounzers.FindAsync(id);
            if (denounce == null)
            {
                return BadRequest("Not found");
            }
            return Ok(denounce);
        }


        [HttpPost("Add")]
        public async Task<IActionResult> Create([FromBody] DenounzerDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not found");
            }
            var denounceDb = new Denounzer
            {
                Name = dto.Name,
                Lastname = dto.Lastname,
                PhoneNumber = dto.PhoneNumber
            };

            _context.Add(denounceDb);
            await _context.SaveChangesAsync();
            return Ok(new { success = true, message = "Created successfully!" });
        }


    }
}
