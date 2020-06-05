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
    public class TbSlideController : ControllerBase
    {
        private readonly DB_Context _context;

        public TbSlideController(DB_Context context)
        {
            _context = context;
        }

        // GET: api/TbSlide
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbSlide>>> GetTbSlide()
        {
            return await _context.TbSlide.ToListAsync();
        }

        // GET: api/TbSlide/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbSlide>> GetTbSlide(int id)
        {
            var tbSlide = await _context.TbSlide.FindAsync(id);

            if (tbSlide == null)
            {
                return NotFound();
            }

            return tbSlide;
        }

        // PUT: api/TbSlide/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbSlide(int id, TbSlide tbSlide)
        {
            if (id != tbSlide.SlideId)
            {
                return BadRequest();
            }

            _context.Entry(tbSlide).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbSlideExists(id))
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

        // POST: api/TbSlide
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TbSlide>> PostTbSlide(TbSlide tbSlide)
        {
            _context.TbSlide.Add(tbSlide);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbSlide", new { id = tbSlide.SlideId }, tbSlide);
        }

        // DELETE: api/TbSlide/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TbSlide>> DeleteTbSlide(int id)
        {
            var tbSlide = await _context.TbSlide.FindAsync(id);
            if (tbSlide == null)
            {
                return NotFound();
            }

            _context.TbSlide.Remove(tbSlide);
            await _context.SaveChangesAsync();

            return tbSlide;
        }

        private bool TbSlideExists(int id)
        {
            return _context.TbSlide.Any(e => e.SlideId == id);
        }

        public List<TbSlide> TbSlideList()
        {
            var slide = new List<TbSlide>()
            {
                new TbSlide(){SlideId=1,SlideTitle="BeeKids-Câu chuyện đồ gỗ",SlideDescription="Đến với BeeKids, các bé sẽ phát triển trí não toàn diện trong môi trường giáo dục chất lượng cao", SlideSubtitle="education makes bright your future",SlideImage="123123khj1ljsd"},
                new TbSlide(){SlideId=2,SlideTitle="BeeKids-Câu chuyện đồ gỗ",SlideDescription="Đến với BeeKids, các bé sẽ phát triển trí não toàn diện trong môi trường giáo dục chất lượng cao", SlideSubtitle="education makes bright your future",SlideImage="123123khj1ljsd"},
                new TbSlide(){SlideId=3,SlideTitle="BeeKids-Câu chuyện đồ gỗ",SlideDescription="Đến với BeeKids, các bé sẽ phát triển trí não toàn diện trong môi trường giáo dục chất lượng cao", SlideSubtitle="education makes bright your future",SlideImage="123123khj1ljsd"},
                new TbSlide(){SlideId=4,SlideTitle="BeeKids-Câu chuyện đồ gỗ",SlideDescription="Đến với BeeKids, các bé sẽ phát triển trí não toàn diện trong môi trường giáo dục chất lượng cao", SlideSubtitle="education makes bright your future",SlideImage="123123khj1ljsd"}

            };
            return slide;
        }
    }
}
