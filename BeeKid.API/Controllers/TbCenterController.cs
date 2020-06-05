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
    public class TbCenterController : ControllerBase
    {
        private readonly DB_Context _context;

        public TbCenterController(DB_Context context)
        {
            _context = context;
        }

        // GET: api/TbCenter
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbCenter>>> GetTbCenter()
        {
            return await _context.TbCenter.ToListAsync();
        }

        // GET: api/TbCenter/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbCenter>> GetTbCenter(int id)
        {
            var tbCenter = await _context.TbCenter.FindAsync(id);

            if (tbCenter == null)
            {
                return NotFound();
            }

            return tbCenter;
        }

        // PUT: api/TbCenter/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbCenter(int id, TbCenter tbCenter)
        {
            if (id != tbCenter.CenterId)
            {
                return BadRequest();
            }

            _context.Entry(tbCenter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbCenterExists(id))
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

        // POST: api/TbCenter
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TbCenter>> PostTbCenter(TbCenter tbCenter)
        {
            _context.TbCenter.Add(tbCenter);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbCenter", new { id = tbCenter.CenterId }, tbCenter);
        }

        // DELETE: api/TbCenter/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TbCenter>> DeleteTbCenter(int id)
        {
            var tbCenter = await _context.TbCenter.FindAsync(id);
            if (tbCenter == null)
            {
                return NotFound();
            }

            _context.TbCenter.Remove(tbCenter);
            await _context.SaveChangesAsync();

            return tbCenter;
        }

        private bool TbCenterExists(int id)
        {
            return _context.TbCenter.Any(e => e.CenterId == id);
        }
    }
}
