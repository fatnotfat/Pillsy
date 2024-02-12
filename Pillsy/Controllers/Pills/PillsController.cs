using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using Service.Interfaces;
using Pillsy.DataTransferObjects.Pill.PillCreateWithPrescriptionDto;
using Pillsy.DataTransferObjects.Account.AccountDTO;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace Pillsy.Controllers.Pills
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PillsController : ControllerBase
    {
        private readonly IPillService _service;
        private readonly IMapper _mapper;

        public PillsController(IPillService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
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

        // POST: api/Pills
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Patient")]
        [HttpPost]
        [Route("add-to-prescription")]
        public async Task<ActionResult<bool>> AddPillToPrescription(PillCreateWithPrescriptionDto pill,Guid prescriptionId)
        {
            try
            {
                string userId = User.FindFirst("PatientId")!.Value;
                var data = _mapper.Map<Pill>(pill);
                data.CreatedBy = Guid.Parse(userId!);
                await _service.AddPillToPrescription(data, prescriptionId);
                return Ok("Add successful!");
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

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
