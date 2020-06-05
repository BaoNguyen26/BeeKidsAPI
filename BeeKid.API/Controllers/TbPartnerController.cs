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
    public class TbPartnerController : ControllerBase
    {
        private readonly DB_Context _context;

        public TbPartnerController(DB_Context context)
        {
            _context = context;
        }

        // GET: api/TbPartner
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbPartner>>> GetTbPartner()
        {
            return await _context.TbPartner.ToListAsync();
        }

        // GET: api/TbPartner/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbPartner>> GetTbPartner(int id)
        {
            var tbPartner = await _context.TbPartner.FindAsync(id);

            if (tbPartner == null)
            {
                return NotFound();
            }

            return tbPartner;
        }

        // PUT: api/TbPartner/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbPartner(int id, TbPartner tbPartner)
        {
            if (id != tbPartner.PartnerId)
            {
                return BadRequest();
            }

            _context.Entry(tbPartner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbPartnerExists(id))
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

        // POST: api/TbPartner
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TbPartner>> PostTbPartner(TbPartner tbPartner)
        {
            _context.TbPartner.Add(tbPartner);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbPartner", new { id = tbPartner.PartnerId }, tbPartner);
        }

        // DELETE: api/TbPartner/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TbPartner>> DeleteTbPartner(int id)
        {
            var tbPartner = await _context.TbPartner.FindAsync(id);
            if (tbPartner == null)
            {
                return NotFound();
            }

            _context.TbPartner.Remove(tbPartner);
            await _context.SaveChangesAsync();

            return tbPartner;
        }

        private bool TbPartnerExists(int id)
        {
            return _context.TbPartner.Any(e => e.PartnerId == id);
        }
    }
}
