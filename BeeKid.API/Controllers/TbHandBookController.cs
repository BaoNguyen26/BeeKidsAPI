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
    public class TbHandBookController : ControllerBase
    {
        private readonly DB_Context _context;

        public TbHandBookController(DB_Context context)
        {
            _context = context;
        }

        // GET: api/TbHandBook
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbHandBook>>> GetTbHandBook()
        {
            return await _context.TbHandBook.ToListAsync();
        }

        // GET: api/TbHandBook/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbHandBook>> GetTbHandBook(int id)
        {
            var tbHandBook = await _context.TbHandBook.FindAsync(id);

            if (tbHandBook == null)
            {
                return NotFound();
            }

            return tbHandBook;
        }

        // PUT: api/TbHandBook/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbHandBook(int id, TbHandBook tbHandBook)
        {
            if (id != tbHandBook.HbId)
            {
                return BadRequest();
            }

            _context.Entry(tbHandBook).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbHandBookExists(id))
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

        // POST: api/TbHandBook
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TbHandBook>> PostTbHandBook(TbHandBook tbHandBook)
        {
            _context.TbHandBook.Add(tbHandBook);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbHandBook", new { id = tbHandBook.HbId }, tbHandBook);
        }

        // DELETE: api/TbHandBook/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TbHandBook>> DeleteTbHandBook(int id)
        {
            var tbHandBook = await _context.TbHandBook.FindAsync(id);
            if (tbHandBook == null)
            {
                return NotFound();
            }

            _context.TbHandBook.Remove(tbHandBook);
            await _context.SaveChangesAsync();

            return tbHandBook;
        }

        private bool TbHandBookExists(int id)
        {
            return _context.TbHandBook.Any(e => e.HbId == id);
        }
    }
}
