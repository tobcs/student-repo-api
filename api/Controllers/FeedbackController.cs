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
    public class FeedbackController : ControllerBase
    {
        private readonly SRAContext _context;

        public FeedbackController(SRAContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Feedback>>> GetMODEL()
        {
            return await _context.Feedback.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Feedback>> GetMODEL(int id)
        {   
            Feedback item = await _context.Feedback.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpPost]
        public async Task<ActionResult<Feedback>> PostFeedback(Feedback item)
        {
            _context.Feedback.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
              nameof(GetMODEL),
              item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMODELItem(int id, Feedback item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Content("Feedback has been updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedbackItem(int id)
        {
            Feedback model = await _context.Feedback.FindAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            _context.Feedback.Remove(model);
            await _context.SaveChangesAsync();

            return Content("Feedback has been removed");
        }
    }
}