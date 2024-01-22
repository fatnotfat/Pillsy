using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using Pillsy.DataTransferObjects.Prescription.PrescriptionCreateDto;
using Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Pillsy.DataTransferObjects.Prescription.PrescriptionUploadImageDto;

namespace Pillsy.Controllers.Prescriptions
{
    [Authorize(Roles = "Patient")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PrescriptionsController : ControllerBase
    {
        //private readonly PillsyDBContext _context;
        private readonly IPrescriptionService _service;
        private readonly IPatientService _patientService;

        public PrescriptionsController(IPrescriptionService service, IPatientService patientService)
        {
            _service = service;
            _patientService = patientService;
        }

        //// GET: api/Prescriptions
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Prescription>>> GetPrescriptions()
        //{
        //  if (_context.Prescriptions == null)
        //  {
        //      return NotFound();
        //  }
        //    return await _context.Prescriptions.ToListAsync();
        //}

        //// GET: api/Prescriptions/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Prescription>> GetPrescription(Guid id)
        //{
        //  if (_context.Prescriptions == null)
        //  {
        //      return NotFound();
        //  }
        //    var prescription = await _context.Prescriptions.FindAsync(id);

        //    if (prescription == null)
        //    {
        //        return NotFound();
        //    }

        //    return prescription;
        //}

        //// PUT: api/Prescriptions/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPrescription(Guid id, Prescription prescription)
        //{
        //    if (id != prescription.PrescriptionID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(prescription).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PrescriptionExists(id))
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

        // POST: api/Prescriptions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Prescription>> PostPrescription(PrescriptionCreateDto prescriptiondto)
        {
            if (await _service.GetAllPrescriptionsAsync() == null)
            {
                return Problem("Entity set 'PillsyDBContext.Prescriptions'  is null.");
            }
            var a = prescriptiondto;


            return Ok(prescriptiondto);
        }
        [HttpPost]
        [Route("upload-image")]
        public async Task<ActionResult<string>> AddImagePrescription(IFormFile file)
        {
            if (await _service.GetAllPrescriptionsAsync() == null)
            {
                return Problem("Entity set 'PillsyDBContext.Prescriptions'  is null.");
            }
            byte[]? imageBytes = null;
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                imageBytes = ms.ToArray();
            }
            string userId = User.FindFirst("AccountId")?.Value;

            var patient = await _patientService.GetPatientByAccountIdAsync(Guid.Parse(userId));

            if (!String.IsNullOrEmpty(userId))
            {
                Prescription pres = new Prescription
                {
                    PrescriptionID = Guid.NewGuid(),
                    PatientID = patient.PatientID,
                    ExaminationDate = null,
                    Status = 1,
                    Index = 0,
                    ImageBase64 = imageBytes
                };

                PrescriptionUploadImageDto imageDto = new PrescriptionUploadImageDto();
                imageDto.ImageBase64 = await _service.AddAsync(pres);
                if (String.IsNullOrEmpty(imageDto.ImageBase64.ToString().Trim()))
                {
                    return BadRequest("Upload failed");
                }

                imageDto.Prescription_Id = pres.PrescriptionID;
                imageDto.User_Id = Guid.Parse(userId);
                return Ok(imageDto);
            }
            else
            {
                return NotFound("User not found!");
            }

        }

        //// DELETE: api/Prescriptions/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeletePrescription(Guid id)
        //{
        //    if (_context.Prescriptions == null)
        //    {
        //        return NotFound();
        //    }
        //    var prescription = await _context.Prescriptions.FindAsync(id);
        //    if (prescription == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Prescriptions.Remove(prescription);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool PrescriptionExists(Guid id)
        //{
        //    return (_context.Prescriptions?.Any(e => e.PrescriptionID == id)).GetValueOrDefault();
        //}
    }
}
