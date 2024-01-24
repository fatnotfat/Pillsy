using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using AutoMapper;
using Service.Interfaces;
using Pillsy.DataTransferObjects.Patient.PatientCreateDTO;
using Pillsy.DataTransferObjects.Account.AccountDTO;
using Pillsy.DataTransferObjects.Patient.PatientDTO;
using Pillsy.DataTransferObjects.Patient.PatientUpdateDto;
using Pillsy.DataTransferObjects.Patient.PatientDetailDto;
using Pillsy.Mappers;

namespace Pillsy.Controllers.Patients
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public PatientsController(IConfiguration configuration, IMapper mapper, IPatientService patientService)
        {
            _configuration = configuration;
            _mapper = mapper;
            _patientService = patientService;
        }

        // GET: api/Patients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
        {
            if (await _patientService.GetAllPatients() == null)
            {
                return NotFound();
            }
            return Ok(await _patientService.GetAllPatients());
        }

        // GET: api/Patients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatient(Guid id)
        {
            if (await _patientService.GetAllPatients() == null)
            {
                return NotFound();
            }
            try
            {
                var patient = await _patientService.GetPatientById(id);

                if (patient == null)
                {
                    return NotFound();
                }

                return patient;
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
            
        }

        // PUT: api/Patients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> UpdatePatient(PatientUpdateDto patient)
        {
            try
            {
                var patientExist = await _patientService.GetPatientById(patient.PatientID);
                if (patientExist == null)
                {
                    return NotFound("Patient " + patient.PatientID + " does not exist!");
                }

                if (!String.IsNullOrEmpty(patient.FirstName?.Trim()))
                {
                    patientExist.FirstName = patient.FirstName.Trim();
                }

                if (!String.IsNullOrEmpty(patient.LastName?.Trim()))
                {
                    patientExist.LastName = patient.LastName.Trim();
                }

                if (patient.DateOfBirth != null)
                {
                    patientExist.DateOfBirth = patient.DateOfBirth;
                }
                if (patient.Gender != null)
                {
                    patientExist.Gender = patient.Gender;
                }
                if (!String.IsNullOrEmpty(patient.PhoneNumber?.Trim()))
                {
                    patientExist.PhoneNumber = patient.PhoneNumber;
                }
                if (!String.IsNullOrEmpty(patient.Address?.Trim()))
                {
                    patientExist.Address = patient.Address;
                }

                var result = await _patientService.UpdatePatientAsync(patientExist);
                if (result)
                    return Ok("Patient updated!");
                return BadRequest("Patient update failed!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Patients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Patient>> AddPatient(PatientCreateDTO patientDTO)
        {

            var data = _mapper.Map<Patient>(patientDTO);
            var patients = await _patientService.GetAllPatients();
            if (patients == null)
            {
                return Problem("Entity set 'PillsyDBContext.Patients'  is null.");
            }
            var result = await _patientService.AddNewPatient(data);
            if (result == null)
            {
                return BadRequest();
            }

            return Ok("Patient " + result.PatientID + " was created!");
        }

        //[HttpGet("{patientId}/prescriptions/detail")]
        //public async Task<ActionResult<PatientDetailDto>> GetPatientDetail(Guid id)
        //{
        //    if (await _patientService.GetAllPatients() == null)
        //    {
        //        return NotFound();
        //    }
        //    var patient = await _patientService.GetPatientById(id);

        //    if (patient == null)
        //    {
        //        return NotFound();
        //    }

        //    var dataPres = patient.Prescriptions;
        //    var patientDto = new PatientDetailDto
        //    {
        //        Userdata = new Userdata
        //        {
        //            Medication_records = new List<Medication_Records>
        //            {
        //                new Medication_Records
        //                {
        //                    Medication = new List<Medication>()
        //                }
        //            }
        //        },
        //        Metadata = new Metadata
        //        {

        //        }
        //    };


        //    var medRecords = new List<Medication_Records>();


        //    foreach (var pres in dataPres)
        //    {
        //        var config = new MapperConfiguration(cfg =>
        //        {
        //            cfg.AddProfile(new PillProfile());
        //            cfg.AddProfile(new ScheduleProfile());
        //            cfg.AddProfile(new PatientProfile());
        //        });
        //        var mapper = config.CreateMapper();
        //        medRecords = pres.Pills.Select(mapper.Map<Pill, Medication_Records>).ToList();
        //        foreach (var med in medRecords)
        //        {
        //            med.Medication = pres.Pills.Where(p => p.PillId.Equals(med.Record_id)).Select(mapper.Map<Pill, Medication>).ToList();
        //        }
        //    }

        //    patientDto.Userdata.Medication_records = medRecords;

        //    return patientDto;

        //}

        //DELETE: api/Patients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(Guid id)
        {
            if (await _patientService.GetAllPatients() == null)
            {
                return NotFound();
            }
            var patient = await _patientService.GetPatientById(id);
            if (patient == null)
            {
                return NotFound();
            }

            

            return NoContent();
        }
    }
}
