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
    public class TbSignUpPartnerrController : ControllerBase
    {
        private readonly DB_Context _context;

        public TbSignUpPartnerrController(DB_Context context)
        {
            _context = context;
        }

        // GET: api/TbSignUpPartnerr
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbSignUpPartnerr>>> GetTbSignUpPartnerr()
        {
            return await _context.TbSignUpPartnerr.ToListAsync();
        }

        // GET: api/TbSignUpPartnerr/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbSignUpPartnerr>> GetTbSignUpPartnerr(int id)
        {
            var tbSignUpPartnerr = await _context.TbSignUpPartnerr.FindAsync(id);

            if (tbSignUpPartnerr == null)
            {
                return NotFound();
            }

            return tbSignUpPartnerr;
        }

        // PUT: api/TbSignUpPartnerr/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbSignUpPartnerr(int id, TbSignUpPartnerr tbSignUpPartnerr)
        {
            if (id != tbSignUpPartnerr.SpId)
            {
                return BadRequest();
            }

            _context.Entry(tbSignUpPartnerr).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbSignUpPartnerrExists(id))
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

        // POST: api/TbSignUpPartnerr
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TbSignUpPartnerr>> PostTbSignUpPartnerr(TbSignUpPartnerr tbSignUpPartnerr)
        {
            _context.TbSignUpPartnerr.Add(tbSignUpPartnerr);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbSignUpPartnerr", new { id = tbSignUpPartnerr.SpId }, tbSignUpPartnerr);
        }

        // DELETE: api/TbSignUpPartnerr/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TbSignUpPartnerr>> DeleteTbSignUpPartnerr(int id)
        {
            var tbSignUpPartnerr = await _context.TbSignUpPartnerr.FindAsync(id);
            if (tbSignUpPartnerr == null)
            {
                return NotFound();
            }

            _context.TbSignUpPartnerr.Remove(tbSignUpPartnerr);
            await _context.SaveChangesAsync();

            return tbSignUpPartnerr;
        }

        private bool TbSignUpPartnerrExists(int id)
        {
            return _context.TbSignUpPartnerr.Any(e => e.SpId == id);
        }
    }
}
