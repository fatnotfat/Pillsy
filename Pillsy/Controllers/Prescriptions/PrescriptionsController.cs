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
using System.Net;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;
using Pillsy.DataTransferObjects.Prescription.PrescriptionRequestOCRDto;
using System.Runtime.Serialization.Json;
using Pillsy.DataTransferObjects.Prescription.PrescriptionRequestOCRInfoDto;
using System.Transactions;
using Pillsy.DataTransferObjects.Prescription.PrescriptionResponseOCRDto;
using System.Collections;
using Org.BouncyCastle.Utilities;
using Pillsy.DataTransferObjects.Prescription.UploadPredictInforPrescriptionDto;

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
        private readonly IPillService _pillService;
        private readonly ICustomerPackageService _customerPackageService;


        public PrescriptionsController(IPrescriptionService service, IPatientService patientService, IPillService pillService, ICustomerPackageService customerPackageService)
        {
            _service = service;
            _patientService = patientService;
            _pillService = pillService;
            _customerPackageService = customerPackageService;
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

                        var pills = prescriptiondto.Data.Medication_records.Select(p => mapper.Map<Medication_record, Pill>(p));
                        foreach (var p in pills)
                        {
                            p.CreatedBy = prescription.CreatedBy;
                            p.ModifiedBy = prescription.ModifiedBy;
                            p.LastModifiedDate = prescription.LastModifiedDate;
                            p.CreatedDate = prescription.CreatedDate;
                            p.Status = prescription.Status;
                            p.Index = prescription.Index;
                            p.PrescriptionId = prescriptiondto.Data.Medication_records_id;
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
        //[HttpPost]
        //[Route("upload-predict-info")]
        //public async Task<ActionResult<string>> AddImagePrescription(PrescriptionCreateDto presCreDto, string imageOcr)
        //{
        //    using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        //    {
        //        try
        //        {
        //            if (await _service.GetAllPrescriptionsAsync() == null)
        //            {
        //                return Problem("Entity set 'PillsyDBContext.Prescriptions'  is null.");
        //            }
        //            string userId = User.FindFirst("AccountId")?.Value;

        //            var patient = await _patientService.GetPatientByAccountIdAsync(Guid.Parse(userId));

        //            if (!String.IsNullOrEmpty(userId))
        //            {
        //                Prescription pres = new Prescription
        //                {
        //                    PrescriptionID = (Guid)presCreDto.Data.Medication_records_id,
        //                    PatientID = patient.PatientID,
        //                    ExaminationDate = null,
        //                    Status = 1,
        //                    Index = 0,
        //                    ImageBase64 = Convert.FromBase64String(imageOcr),
        //                    CreatedDate = DateTime.Now,
        //                };

        //                PrescriptionUploadImageDto imageDto = new PrescriptionUploadImageDto();
        //                imageDto.ImageBase64 = await _service.AddAsync(pres);
        //                if (String.IsNullOrEmpty(imageDto.ImageBase64.ToString().Trim()))
        //                {
        //                    return BadRequest("Upload failed");
        //                }

        //                //imageDto.Prescription_Id = pres.PrescriptionID;
        //                //imageDto.User_Id = Guid.Parse(userId);
        //                //PrescriptionRequestOCRInfoDto prescriptionRequestOCRInfoDto = new PrescriptionRequestOCRInfoDto
        //                //{
        //                //    User_Id = patient.PatientID,
        //                //    Prescription_Id = pres.PrescriptionID,
        //                //    Data = presCreDto.Data
        //                //};

        //                //var json2 = JsonConvert.SerializeObject(prescriptionRequestOCRInfoDto);
        //                //var data2 = new StringContent(json2, Encoding.UTF8, "application/json");
        //                //var url2 = "http://35.232.72.106:8003/api/v1/predict-info/";
        //                //using var client2 = new HttpClient();
        //                //var response2 = await client2.PostAsync(url2, data2);
        //                //var result2 = await response2.Content.ReadAsStringAsync();


        //                //var prescriptiondto = JsonConvert.DeserializeObject<PrescriptionCreateDto>(result2);
        //                await UpdatePrescription(presCreDto);
        //                scope.Complete();
        //                return Ok("Prescription add complete!");
        //            }
        //            else
        //            {
        //                scope.Dispose();
        //                return NotFound("User not found!");
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            scope.Dispose();
        //            return BadRequest($"{ex.Message}");
        //        }
        //    }

        //}

        [HttpPost]
        [Route("upload-predict-info")]
        public async Task<ActionResult> UploadPredictInforPrescription(UploadPredictInforPrescriptionDto uploadPresDto)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    if (await _service.GetAllPrescriptionsAsync() == null)
                    {
                        return Problem("Entity set 'PillsyDBContext.Prescriptions'  is null.");
                    }
                    string userId = User.FindFirst("AccountId")?.Value;

                    var patient = await _patientService.GetPatientByAccountIdAsync(Guid.Parse(userId));

                    if (!String.IsNullOrEmpty(userId))
                    {
                        await _service.AddAsync(uploadPresDto.Prescription);
                        await UpdatePrescription(uploadPresDto.PrescriptionCreateDto);
                        var customerPackage = await _customerPackageService.GetCustomerPackageByPatientId(uploadPresDto.Prescription.PatientID);
                        if (customerPackage != null && customerPackage.SubscriptionPackage.PackageType.Equals("Basic"))
                        {
                            var number = Int32.Parse(customerPackage.NumberScan.Trim());
                            number--;
                            customerPackage.NumberScan = number.ToString();
                        }
                        scope.Complete();
                        return Ok("Add successfully!");
                    }
                    else
                    {
                        scope.Dispose();
                        return NotFound("User not found!");
                    }
                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    return BadRequest($"{ex.Message}");
                }
            }

        }


        [HttpPost]
        [Route("return-predict-info")]
        public async Task<ActionResult> ReturnPredictInforPrescription(PrescriptionResponseOCRDto ocrDto)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    if (await _service.GetAllPrescriptionsAsync() == null)
                    {
                        return Problem("Entity set 'PillsyDBContext.Prescriptions'  is null.");
                    }
                    string userId = User.FindFirst("AccountId")?.Value;

                    var patient = await _patientService.GetPatientByAccountIdAsync(Guid.Parse(userId));

                    if (!String.IsNullOrEmpty(userId))
                    {
                        Prescription pres = new Prescription
                        {
                            PrescriptionID = (Guid)ocrDto.Prescription_Id,
                            PatientID = (Guid)ocrDto.User_Id,
                            ExaminationDate = null,
                            Status = 1,
                            Index = 0,
                            ImageBase64 = Convert.FromBase64String(ocrDto.Image!),
                            CreatedDate = DateTime.UtcNow,
                        };

                        PrescriptionUploadImageDto imageDto = new PrescriptionUploadImageDto();
                        imageDto.ImageBase64 = Convert.FromBase64String(ocrDto.Image!);
                        if (String.IsNullOrEmpty(imageDto.ImageBase64.ToString().Trim()))
                        {
                            return BadRequest("Upload failed");
                        }

                        imageDto.Prescription_Id = pres.PrescriptionID;
                        imageDto.User_Id = Guid.Parse(userId);
                        PrescriptionRequestOCRInfoDto prescriptionRequestOCRInfoDto = new PrescriptionRequestOCRInfoDto
                        {
                            User_Id = ocrDto.User_Id,
                            Prescription_Id = ocrDto.Prescription_Id,
                            Data = ocrDto.Data
                        };

                        var json2 = JsonConvert.SerializeObject(prescriptionRequestOCRInfoDto);
                        var data2 = new StringContent(json2, Encoding.UTF8, "application/json");
                        var url2 = "http://35.232.72.106:8003/api/v1/predict-info/";
                        using var client2 = new HttpClient();

                        HttpResponseMessage response2;
                        int retryCount = 20;
                        do
                        {
                            response2 = await client2.PostAsync(url2, data2);
                            retryCount--;
                        } while (!response2.IsSuccessStatusCode && retryCount > 0);

                        if (!response2.IsSuccessStatusCode)
                        {
                            return BadRequest("Failed to predict info after multiple attempts.");
                        }

                        //var response2 = await client2.PostAsync(url2, data2);
                        var result2 = await response2.Content.ReadAsStringAsync();


                        var prescriptiondto = JsonConvert.DeserializeObject<PrescriptionCreateDto>(result2);
                        while (prescriptiondto.Status.Equals("404") || prescriptiondto.Status.Equals("400") || prescriptiondto.Status.Equals("500"))
                        {
                            response2 = await client2.PostAsync(url2, data2);
                            result2 = await response2.Content.ReadAsStringAsync();

                            if (!response2.IsSuccessStatusCode)
                            {
                                return BadRequest("Failed to predict info after multiple attempts.");
                            }
                            prescriptiondto = JsonConvert.DeserializeObject<PrescriptionCreateDto>(result2);
                            foreach (var date in prescriptiondto.Data.Medication_records)
                            {
                                if (date.Start_date == null)
                                {
                                    date.Start_date = DateTime.UtcNow;
                                    pres.CreatedDate = date.Start_date;

                                }
                                pres.CreatedDate = date.Start_date;

                            }
                        }
                        scope.Complete();
                        return Ok(new ReturnPredictInforPrescriptionDto
                        {
                            PrescriptionCreateDto = prescriptiondto,
                            Prescription = pres
                        });
                    }
                    else
                    {
                        scope.Dispose();
                        return NotFound("User not found!");
                    }
                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    return BadRequest($"{ex.Message}");
                }
            }

        }





        [HttpPost]
        [Route("upload-ocr-image")]
        public async Task<ActionResult<PrescriptionResponseOCRDto>> AddOCRImagePrescription(IFormFile file)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
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


                    var customerPackage = await _customerPackageService.GetCustomerPackageByPatientId(patient.PatientID);
                    if(customerPackage != null && Int32.Parse(customerPackage.NumberScan) > 0)
                    {
                        if (!String.IsNullOrEmpty(userId))
                        {



                            //predict ocr
                            PrescriptionRequestOCRDto prescriptionRequestOCRDto = new PrescriptionRequestOCRDto();
                            prescriptionRequestOCRDto.Prescription_Id = Guid.NewGuid();
                            prescriptionRequestOCRDto.User_Id = patient.PatientID;
                            prescriptionRequestOCRDto.Image = Convert.ToBase64String(imageBytes);


                            var json = JsonConvert.SerializeObject(prescriptionRequestOCRDto);
                            var data = new StringContent(json, Encoding.UTF8, "application/json");
                            var url = "http://35.232.72.106:8003/api/v1/predict-ocr/";
                            using var client = new HttpClient();
                            var response = await client.PostAsync(url, data);
                            var result = await response.Content.ReadAsStringAsync();

                            var bsObj = JsonConvert.DeserializeObject<PrescriptionResponseOCRDto>(result);

                            return Ok(bsObj);
                        }
                        else
                        {
                            scope.Dispose();
                            return NotFound("User not found!");
                        }
                    }
                    else
                    {
                        return BadRequest("Your trial has expired, please register for another package to use!");
                    }  
                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    return BadRequest($"{ex.Message}");
                }
            }

        }

        [HttpGet]
        [Route("patient/{patientId}/all-prescription")]
        public async Task<ActionResult<IEnumerable<Prescription>>> GetPrescriptionsByPatientId(Guid patientId)
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


        [HttpGet]
        [Route("patient/{patientId}/all-prescription-by-date/{date}")]
        public async Task<ActionResult<IEnumerable<Prescription>>> GetPrescriptionsByPatientId(Guid patientId, int date)
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

                var prescriptions = result.Where(p => p.CreatedDate!.Value.Date.Equals(date));

                return Ok(prescriptions);
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

        [HttpGet]
        [Route("patient/{patientId}/all-prescription-by-month/{month}")]
        public async Task<ActionResult<IEnumerable<Prescription>>> GetPrescriptionsByPatientIdAndMonth(Guid patientId, int month)
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

                var prescriptions = result.Where(p => p.CreatedDate!.Value.Date.Equals(month));

                return Ok(prescriptions);
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

        [HttpGet]
        [Route("patient/{patientId}/all-prescription-by-year/{year}")]
        public async Task<ActionResult<IEnumerable<Prescription>>> GetPrescriptionsByPatientIdAndYear(Guid patientId, int year)
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

                var prescriptions = result.Where(p => p.CreatedDate!.Value.Date.Equals(year));

                return Ok(prescriptions);
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

    }
}
