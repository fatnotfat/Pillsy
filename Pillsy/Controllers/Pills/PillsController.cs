using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using Service.Interfaces;

namespace Pillsy.Controllers.Pills
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PillsController : ControllerBase
    {
        private readonly IPillService _service;

        public PillsController(IPillService service)
        {
            _service = service;
        }





        // GET: api/Pills
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pill>>> GetPillsAsync()
        {
            if (await _service.GetAllPillsAsync() == null)
            {
                return NotFound();
            }
            return Ok(await _service.GetAllPillsAsync());
        }

        // GET: api/Pills/5
        [HttpGet("prescription-managed/{prescriptionId}")]
        public async Task<ActionResult<Pill>> GetPillByPrescriptionIdAsync(Guid prescriptionId)
        {
            if (await _service.GetAllPillsAsync() == null)
            {
                return NotFound();
            }
            var pills = await _service.GetPillsByPrescriptionIdAsync(prescriptionId);

            if (pills == null)
            {
                return NotFound();
            }

            return Ok(pills);
        }

        //// PUT: api/Pills/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPill(Guid id, Pill pill)
        //{
        //    if (id != pill.PillId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(pill).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PillExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Pills
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Pill>> PostPill(Pill pill)
        //{
        //  if (_context.Pills == null)
        //  {
        //      return Problem("Entity set 'PillsyDBContext.Pills'  is null.");
        //  }
        //    _context.Pills.Add(pill);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetPill", new { id = pill.PillId }, pill);
        //}

        //// DELETE: api/Pills/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeletePill(Guid id)
        //{
        //    if (_context.Pills == null)
        //    {
        //        return NotFound();
        //    }
        //    var pill = await _context.Pills.FindAsync(id);
        //    if (pill == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Pills.Remove(pill);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool PillExists(Guid id)
        //{
        //    return (_context.Pills?.Any(e => e.PillId == id)).GetValueOrDefault();
        //}
    }
}
