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
    public class TbEventController : ControllerBase
    {
        private readonly DB_Context _context;

        public TbEventController(DB_Context context)
        {
            _context = context;
        }

        // GET: api/TbEvent
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbEvent>>> GetTbEvent()
        {
            return await _context.TbEvent.ToListAsync();
        }

        // GET: api/TbEvent/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbEvent>> GetTbEvent(int id)
        {
            var tbEvent = await _context.TbEvent.FindAsync(id);

            if (tbEvent == null)
            {
                return NotFound();
            }

            return tbEvent;
        }

        // PUT: api/TbEvent/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbEvent(int id, TbEvent tbEvent)
        {
            if (id != tbEvent.EventId)
            {
                return BadRequest();
            }

            _context.Entry(tbEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbEventExists(id))
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

        // POST: api/TbEvent
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TbEvent>> PostTbEvent(TbEvent tbEvent)
        {
            _context.TbEvent.Add(tbEvent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbEvent", new { id = tbEvent.EventId }, tbEvent);
        }

        // DELETE: api/TbEvent/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TbEvent>> DeleteTbEvent(int id)
        {
            var tbEvent = await _context.TbEvent.FindAsync(id);
            if (tbEvent == null)
            {
                return NotFound();
            }

            _context.TbEvent.Remove(tbEvent);
            await _context.SaveChangesAsync();

            return tbEvent;
        }

        private bool TbEventExists(int id)
        {
            return _context.TbEvent.Any(e => e.EventId == id);
        }
    }
}
