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
    public class TbTypePartnerController : ControllerBase
    {
        private readonly DB_Context _context;

        public TbTypePartnerController(DB_Context context)
        {
            _context = context;
        }

        // GET: api/TbTypePartner
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbTypePartner>>> GetTbTypePartner()
        {
            return await _context.TbTypePartner.ToListAsync();
        }

        // GET: api/TbTypePartner/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbTypePartner>> GetTbTypePartner(int id)
        {
            var tbTypePartner = await _context.TbTypePartner.FindAsync(id);

            if (tbTypePartner == null)
            {
                return NotFound();
            }

            return tbTypePartner;
        }

        // PUT: api/TbTypePartner/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbTypePartner(int id, TbTypePartner tbTypePartner)
        {
            if (id != tbTypePartner.TypepartnerId)
            {
                return BadRequest();
            }

            _context.Entry(tbTypePartner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbTypePartnerExists(id))
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

        // POST: api/TbTypePartner
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TbTypePartner>> PostTbTypePartner(TbTypePartner tbTypePartner)
        {
            _context.TbTypePartner.Add(tbTypePartner);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbTypePartner", new { id = tbTypePartner.TypepartnerId }, tbTypePartner);
        }

        // DELETE: api/TbTypePartner/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TbTypePartner>> DeleteTbTypePartner(int id)
        {
            var tbTypePartner = await _context.TbTypePartner.FindAsync(id);
            if (tbTypePartner == null)
            {
                return NotFound();
            }

            _context.TbTypePartner.Remove(tbTypePartner);
            await _context.SaveChangesAsync();

            return tbTypePartner;
        }

        private bool TbTypePartnerExists(int id)
        {
            return _context.TbTypePartner.Any(e => e.TypepartnerId == id);
        }
    }
}
