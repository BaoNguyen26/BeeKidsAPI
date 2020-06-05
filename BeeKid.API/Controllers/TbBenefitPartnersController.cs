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
    public class TbBenefitPartnersController : ControllerBase
    {
        private readonly DB_Context _context;

        public TbBenefitPartnersController(DB_Context context)
        {
            _context = context;
        }

        // GET: api/TbBenefitPartners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbBenefitPartner>>> GetTbBenefitPartner()
        {
            return await _context.TbBenefitPartner.ToListAsync();
        }

        // GET: api/TbBenefitPartners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbBenefitPartner>> GetTbBenefitPartner(int id)
        {
            var tbBenefitPartner = await _context.TbBenefitPartner.FindAsync(id);

            if (tbBenefitPartner == null)
            {
                return NotFound();
            }

            return tbBenefitPartner;
        }

        // PUT: api/TbBenefitPartners/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbBenefitPartner(int id, TbBenefitPartner tbBenefitPartner)
        {
            if (id != tbBenefitPartner.BpId)
            {
                return BadRequest();
            }

            _context.Entry(tbBenefitPartner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbBenefitPartnerExists(id))
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

        // POST: api/TbBenefitPartners
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TbBenefitPartner>> PostTbBenefitPartner(TbBenefitPartner tbBenefitPartner)
        {
            _context.TbBenefitPartner.Add(tbBenefitPartner);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbBenefitPartner", new { id = tbBenefitPartner.BpId }, tbBenefitPartner);
        }

        // DELETE: api/TbBenefitPartners/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TbBenefitPartner>> DeleteTbBenefitPartner(int id)
        {
            var tbBenefitPartner = await _context.TbBenefitPartner.FindAsync(id);
            if (tbBenefitPartner == null)
            {
                return NotFound();
            }

            _context.TbBenefitPartner.Remove(tbBenefitPartner);
            await _context.SaveChangesAsync();

            return tbBenefitPartner;
        }

        private bool TbBenefitPartnerExists(int id)
        {
            return _context.TbBenefitPartner.Any(e => e.BpId == id);
        }
    }
}
