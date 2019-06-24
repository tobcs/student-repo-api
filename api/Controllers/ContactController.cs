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
    public class ContactController : ControllerBase
    {
        private readonly SRAContext _context;

        public ContactController(SRAContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetMODEL()
        {
            return await _context.Contact.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetMODEL(int id)
        {   
            Contact item = await _context.Contact.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpPost]
        public async Task<ActionResult<Contact>> PostFeedback(Contact item)
        {
            _context.Contact.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
              nameof(GetMODEL),
              item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutContact(int id, Contact item)
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
        public async Task<IActionResult> DeleteContact(int id)
        {
            Contact model = await _context.Contact.FindAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            _context.Contact.Remove(model);
            await _context.SaveChangesAsync();

            return Content("Feedback has been removed");
        }
    }
}