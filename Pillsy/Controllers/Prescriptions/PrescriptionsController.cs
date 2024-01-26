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
using AutoMapper;
using Pillsy.DataTransferObjects.Account.AccountDTO;
using Service;
using Pillsy.Mappers;
using Pillsy.DataTransferObjects.Patient.PatientCreateDTO;

namespace Pillsy.Controllers.Prescriptions
{
    [Authorize(Roles = "Patient")]
    [Route("api/v1/prescription-management/[controller]")]
    [ApiController]
    public class PrescriptionsController : ControllerBase
    {
        //private readonly PillsyDBContext _context;
        private readonly IPrescriptionService _service;
        private readonly IPatientService _patientService;
        private readonly IScheduleService _scheduleService;
        private readonly IPillService _pillService;


        public PrescriptionsController(IPrescriptionService service, IPatientService patientService, IScheduleService scheduleService, IPillService pillService)
        {
            _service = service;
            _patientService = patientService;
            _scheduleService = scheduleService;
            _pillService = pillService;
        }

        // GET: api/Prescriptions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prescription>>> GetPrescriptions()
        {
            if (await _service.GetAllPrescriptionsAsync() == null)
            {
                return NotFound();
            }
            return Ok(await _service.GetAllPrescriptionsAsync());
        }

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
        public async Task<ActionResult<Prescription>> UpdatePrescription(PrescriptionCreateDto prescriptiondto)
        {
            try
            {
                if (await _service.GetAllPrescriptionsAsync() == null)
                {
                    return Problem("Entity set 'PillsyDBContext.Prescriptions'  is null.");
                }
                //create map
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new PrescriptionProfile());
                    cfg.AddProfile(new ScheduleProfile());
                    cfg.AddProfile(new PillProfile());
                });
                var mapper = config.CreateMapper();
                //End create map

                //transfer from account to account dto

                var data = mapper.Map<Prescription>(prescriptiondto);

                var prescription = await _service.GetPrescriptionsByPrescriptionIdAsync(data.PrescriptionID);
                if (prescription != null)
                {
                    if (data.CreatedBy != null)
                    {
                        prescription.CreatedBy = data.CreatedBy;
                    }
                    if (data.CreatedDate != null)
                    {
                        prescription.CreatedDate = data.CreatedDate;
                    }
                    if (data.Index != 0)
                    {
                        prescription.Index = data.Index;
                    }
                    if (data.ModifiedBy != null)
                    {
                        prescription.ModifiedBy = data.ModifiedBy;
                    }
                    if (data.LastModifiedDate != null)
                    {
                        prescription.LastModifiedDate = data.LastModifiedDate;
                    }
                    if (data.Diagnosis != null)
                    {
                        prescription.Diagnosis = data.Diagnosis;
                    }
                    if (data.Status != 0)
                    {
                        prescription.Status = data.Status;
                    }
                    var result = await _service.UpdatePrescriptionAsync(prescription);
                    if (result != null)
                    {
                        var medicalRecord = prescriptiondto.User_data.Medication_records.ToList().First();
                        var schedule = new Schedule
                        {
                            DateStart = mapper.Map<Schedule>(medicalRecord).DateStart,
                            DateEnd = mapper.Map<Schedule>(medicalRecord).DateEnd,
                        };
                        var data1 = await _scheduleService.AddScheduleAsync(schedule);


                        var pills = prescriptiondto.User_data.Medication_records.Select(p => mapper.Map<Medication_records, Pill>(p));
                        foreach (var p in pills)
                        {
                            p.CreatedBy = prescription.CreatedBy;
                            p.ModifiedBy = prescription.ModifiedBy;
                            p.LastModifiedDate = prescription.LastModifiedDate;
                            p.CreatedDate = prescription.CreatedDate;
                            p.Status = prescription.Status;
                            p.Index = prescription.Index;
                            p.PrescriptionId = prescriptiondto.User_data.Medication_records_id;
                            p.ScheduleId = data1.ScheduleId;
                            await _pillService.AddPillAsync(p);
                        }


                        return Ok("Add success!");
                    }
                }
                return BadRequest("Add failed!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

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

        [HttpPost]
        [Route("patient/all-prescription")]
        public async Task<ActionResult<IEnumerable<Prescription>>> GetPrescriptionsByPatientId([FromBody] Guid patientId)
        {
            try
            {
                var patients = await _patientService.GetAllPatients();
                if (patients == null)
                {
                    return Problem("Entity set 'PillsyDBContext.Patients'  is null.");
                }

                var patient = await _patientService.GetPatientById(patientId);
                if (patient == null)
                {
                    return NotFound("Patient not found!");
                }
                var result = await _service.GetPrescriptionsByPatientIdAsync(patientId);
                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                switch (ex.Message)
                {
                    case "Patient not found!":
                        return NotFound(ex.Message);

                    default:
                        return BadRequest(ex.Message);
                }
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
