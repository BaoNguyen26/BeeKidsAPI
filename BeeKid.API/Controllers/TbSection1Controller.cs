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
    public class TbSection1Controller : ControllerBase
    {
        private readonly DB_Context _context;

        public TbSection1Controller(DB_Context context)
        {
            _context = context;
        }

        // GET: api/TbSection1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbSection1>>> GetTbSection1()
        {
            return await _context.TbSection1.ToListAsync();
        }

        // GET: api/TbSection1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbSection1>> GetTbSection1(int id)
        {
            var tbSection1 = await _context.TbSection1.FindAsync(id);

            if (tbSection1 == null)
            {
                return NotFound();
            }

            return tbSection1;
        }

        // PUT: api/TbSection1/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbSection1(int id, TbSection1 tbSection1)
        {
            if (id != tbSection1.Section1Id)
            {
                return BadRequest();
            }

            _context.Entry(tbSection1).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbSection1Exists(id))
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

        // POST: api/TbSection1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TbSection1>> PostTbSection1(TbSection1 tbSection1)
        {
            _context.TbSection1.Add(tbSection1);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbSection1", new { id = tbSection1.Section1Id }, tbSection1);
        }

        // DELETE: api/TbSection1/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TbSection1>> DeleteTbSection1(int id)
        {
            var tbSection1 = await _context.TbSection1.FindAsync(id);
            if (tbSection1 == null)
            {
                return NotFound();
            }

            _context.TbSection1.Remove(tbSection1);
            await _context.SaveChangesAsync();

            return tbSection1;
        }

        private bool TbSection1Exists(int id)
        {
            return _context.TbSection1.Any(e => e.Section1Id == id);
        }
    }
}
