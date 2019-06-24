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
    public class IssueController : ControllerBase
    {
        private readonly SRAContext _context;

        public IssueController(SRAContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Issue>>> GetMODEL()
        {
            return await _context.Issue.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Issue>> GetMODEL(int id)
        {   
            Issue item = await _context.Issue.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpPost]
        public async Task<ActionResult<Issue>> PostFeedback(Issue item)
        {
            _context.Issue.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
              nameof(GetMODEL),
              item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMODELItem(int id, Issue item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Content("Issue has been updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIssue(int id)
        {
            Issue model = await _context.Issue.FindAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            _context.Issue.Remove(model);
            await _context.SaveChangesAsync();

            return Content("Issue has been removed");
        }
    }
}