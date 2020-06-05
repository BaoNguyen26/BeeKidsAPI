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
    public class TbSignUpController : ControllerBase
    {
        private readonly DB_Context _context;

        public TbSignUpController(DB_Context context)
        {
            _context = context;
        }

        // GET: api/TbSignUp
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbSignUp>>> GetTbSignUp()
        {
            return await _context.TbSignUp.ToListAsync();
        }

        // GET: api/TbSignUp/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbSignUp>> GetTbSignUp(int id)
        {
            var tbSignUp = await _context.TbSignUp.FindAsync(id);

            if (tbSignUp == null)
            {
                return NotFound();
            }

            return tbSignUp;
        }

        // PUT: api/TbSignUp/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbSignUp(int id, TbSignUp tbSignUp)
        {
            if (id != tbSignUp.SignupId)
            {
                return BadRequest();
            }

            _context.Entry(tbSignUp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbSignUpExists(id))
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

        // POST: api/TbSignUp
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TbSignUp>> PostTbSignUp(TbSignUp tbSignUp)
        {
            _context.TbSignUp.Add(tbSignUp);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbSignUpExists(tbSignUp.SignupId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbSignUp", new { id = tbSignUp.SignupId }, tbSignUp);
        }

        // DELETE: api/TbSignUp/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TbSignUp>> DeleteTbSignUp(int id)
        {
            var tbSignUp = await _context.TbSignUp.FindAsync(id);
            if (tbSignUp == null)
            {
                return NotFound();
            }

            _context.TbSignUp.Remove(tbSignUp);
            await _context.SaveChangesAsync();

            return tbSignUp;
        }

        private bool TbSignUpExists(int id)
        {
            return _context.TbSignUp.Any(e => e.SignupId == id);
        }
    }
}
