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
using Microsoft.AspNetCore.Identity;
using System.Transactions;
using Microsoft.AspNetCore.Authorization;

namespace Pillsy.Controllers.Patients
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IAccountService _accountService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public PatientsController(IConfiguration configuration, IMapper mapper, IPatientService patientService, IAccountService accountService, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _configuration = configuration;
            _mapper = mapper;
            _patientService = patientService;
            _accountService = accountService;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("new-by-date/{date}")]
        public async Task<ActionResult<IEnumerable<Patient>>> GetNewPatientsByDate(int date)
        {
            if (await _patientService.GetAllPatients() == null)
            {
                return NotFound();
            }
            return Ok(await _patientService.GetNewPatientsByDateAsync(date));
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("new-by-month/{month}")]
        public async Task<ActionResult<IEnumerable<Patient>>> GetNewPatientsByMonth(int month)
        {
            if (await _patientService.GetAllPatients() == null)
            {
                return NotFound();
            }
            return Ok(await _patientService.GetNewPatientsByMonthAsync(month));
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("new-by-year/{year}")]
        public async Task<ActionResult<IEnumerable<Patient>>> GetNewPatientsByYear(int year)
        {
            if (await _patientService.GetAllPatients() == null)
            {
                return NotFound();
            }
            return Ok(await _patientService.GetNewPatientsByYearAsync(year));
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
            catch (Exception ex)
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
        [Route("sign-up")]
        public async Task<ActionResult<Patient>> AddPatient(PatientCreateDTO patientDTO)
        {

            var data = _mapper.Map<Patient>(patientDTO);
            var patients = await _patientService.GetAllPatients();
            if (patients == null)
            {
                return Problem("Entity set 'PillsyDBContext.Patients'  is null.");
            }
            IdentityUser user = new()
            {
                Email = patientDTO.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = patientDTO.FirstName + patientDTO.LastName,
                TwoFactorEnabled = false
            };

            string mess = "";
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var result = await _patientService.AddNewPatient(data);
                    if (result != null)
                    {
                        var account = await _accountService.GetAccountById(result.AccountId);
                        var resultAspUser = await _userManager.CreateAsync(user, account.Password);


                        if (!resultAspUser.Succeeded)
                        {

                            var message = string.Join(", ", resultAspUser.Errors.Select(x => "Code: " + x.Code + " Description: " + x.Description));
                            return StatusCode(StatusCodes.Status500InternalServerError,
                                new Response { Status = "Error", Message = message });
                            mess = message;
                        }
                        scope.Complete();
                        return Ok("Patient " + result.PatientID + " was created!");
                    }
                    else
                    {
                        return BadRequest("can not add this patient, please try again!");
                    }
                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    if (mess.Length > 0)
                    {
                        return BadRequest($"{mess}");

                    }
                    return BadRequest($"{ex.Message}");
                }
            }

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
