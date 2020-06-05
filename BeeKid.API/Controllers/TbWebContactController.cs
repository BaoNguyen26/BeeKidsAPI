using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeeKid.API.Models;

namespace BeeKid.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TbWebContactController : ControllerBase
    {
        private readonly DB_Context _context;

        public TbWebContactController(DB_Context context)
        {
            _context = context;
        }

        // GET: api/TbWebContact
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbWebContact>>> GetTbWebContact()
        {
            return await _context.TbWebContact.ToListAsync();
        }

        // GET: api/TbWebContact/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbWebContact>> GetTbWebContact(int id)
        {
            var tbWebContact = await _context.TbWebContact.FindAsync(id);

            if (tbWebContact == null)
            {
                return NotFound();
            }

            return tbWebContact;
        }

        // PUT: api/TbWebContact/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbWebContact(int id, TbWebContact tbWebContact)
        {
            if (id != tbWebContact.WebcontactId)
            {
                return BadRequest();
            }

            _context.Entry(tbWebContact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbWebContactExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TbWebContact
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TbWebContact>> PostTbWebContact(TbWebContact tbWebContact)
        {
            _context.TbWebContact.Add(tbWebContact);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbWebContact", new { id = tbWebContact.WebcontactId }, tbWebContact);
        }

        // DELETE: api/TbWebContact/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TbWebContact>> DeleteTbWebContact(int id)
        {
            var tbWebContact = await _context.TbWebContact.FindAsync(id);
            if (tbWebContact == null)
            {
                return NotFound();
            }

            _context.TbWebContact.Remove(tbWebContact);
            await _context.SaveChangesAsync();

            return tbWebContact;
        }

        private bool TbWebContactExists(int id)
        {
            return _context.TbWebContact.Any(e => e.WebcontactId == id);
        }
    }
}
