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
    public class TbExpertController : ControllerBase
    {
        private readonly DB_Context _context;

        public TbExpertController(DB_Context context)
        {
            _context = context;
        }

        // GET: api/TbExpert
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbExpert>>> GetTbExpert()
        {
            return await _context.TbExpert.ToListAsync();
        }

        // GET: api/TbExpert/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbExpert>> GetTbExpert(int id)
        {
            var tbExpert = await _context.TbExpert.FindAsync(id);

            if (tbExpert == null)
            {
                return NotFound();
            }

            return tbExpert;
        }

        // PUT: api/TbExpert/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbExpert(int id, TbExpert tbExpert)
        {
            if (id != tbExpert.ExpertId)
            {
                return BadRequest();
            }

            _context.Entry(tbExpert).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbExpertExists(id))
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

        // POST: api/TbExpert
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TbExpert>> PostTbExpert(TbExpert tbExpert)
        {
            _context.TbExpert.Add(tbExpert);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbExpert", new { id = tbExpert.ExpertId }, tbExpert);
        }

        // DELETE: api/TbExpert/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TbExpert>> DeleteTbExpert(int id)
        {
            var tbExpert = await _context.TbExpert.FindAsync(id);
            if (tbExpert == null)
            {
                return NotFound();
            }

            _context.TbExpert.Remove(tbExpert);
            await _context.SaveChangesAsync();

            return tbExpert;
        }

        private bool TbExpertExists(int id)
        {
            return _context.TbExpert.Any(e => e.ExpertId == id);
        }
    }
}
