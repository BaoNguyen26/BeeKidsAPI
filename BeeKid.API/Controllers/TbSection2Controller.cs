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
    public class TbSection2Controller : ControllerBase
    {
        private readonly DB_Context _context;

        public TbSection2Controller(DB_Context context)
        {
            _context = context;
        }

        // GET: api/TbSection2
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbSection2>>> GetTbSection2()
        {
            return await _context.TbSection2.ToListAsync();
        }

        // GET: api/TbSection2/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbSection2>> GetTbSection2(int id)
        {
            var tbSection2 = await _context.TbSection2.FindAsync(id);

            if (tbSection2 == null)
            {
                return NotFound();
            }

            return tbSection2;
        }

        // PUT: api/TbSection2/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbSection2(int id, TbSection2 tbSection2)
        {
            if (id != tbSection2.Section2Id)
            {
                return BadRequest();
            }

            _context.Entry(tbSection2).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbSection2Exists(id))
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

        // POST: api/TbSection2
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TbSection2>> PostTbSection2(TbSection2 tbSection2)
        {
            _context.TbSection2.Add(tbSection2);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbSection2", new { id = tbSection2.Section2Id }, tbSection2);
        }

        // DELETE: api/TbSection2/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TbSection2>> DeleteTbSection2(int id)
        {
            var tbSection2 = await _context.TbSection2.FindAsync(id);
            if (tbSection2 == null)
            {
                return NotFound();
            }

            _context.TbSection2.Remove(tbSection2);
            await _context.SaveChangesAsync();

            return tbSection2;
        }

        private bool TbSection2Exists(int id)
        {
            return _context.TbSection2.Any(e => e.Section2Id == id);
        }
    }
}
