using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly SRAContext _context;

        public StudentController(SRAContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Students>>> GetMODEL()
        {
            return await _context.Students.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Students>> GetMODEL(int id)
        {   
            Students item = await _context.Students.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpPost]
        public async Task<ActionResult<Students>> PostFeedback(Students item)
        {
            _context.Students.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
              nameof(GetMODEL),
              item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMODELItem(int id, Students item)
        {
            if (id != item.StudentNumber)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Content("Students has been updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedbackItem(int id)
        {
            Students model = await _context.Students.FindAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            _context.Students.Remove(model);
            await _context.SaveChangesAsync();

            return Content("Student has been removed");
        }
    }
}