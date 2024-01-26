using BusinessObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessObject
{
    public class PatientDAO
    {

        private static PatientDAO? instance = null;

        public static PatientDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PatientDAO();
                }
                return instance;
            }
        }

        public async Task<IEnumerable<Patient>> GetPatientsAsync()
        {
            var _context = new PillsyDBContext();
            var result = await _context.Patients.ToListAsync();
            if (result == null)
            {
                throw new Exception("Patient not found!");
            }
            return result;
        }

        public async Task<Patient> GetPatientByIdAsync(Guid patientId)
        {
            try
            {
                var _context = new PillsyDBContext();
                var patient = await _context.Patients.Include(p => p.Prescriptions).FirstOrDefaultAsync(a => a.PatientID.Equals(patientId));
                if (patient == null)
                {
                    throw new Exception("Patient not found!");
                }
                return patient;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Patient> GetPatientByAccountIdAsync(Guid accountId)
        {
            var _context = new PillsyDBContext();
            var patient = await _context.Patients.FirstOrDefaultAsync(p => p.AccountId.Equals(accountId));
            return patient;
        }

        public async Task<bool> UpdatePatientAsync(Patient patient)
        {
            var isSuccess = false;
            try
            {
                var _context = new PillsyDBContext();
                _context.Entry(patient).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                isSuccess = true;
            }
            catch (Exception)
            {
                throw;
            }
            return isSuccess;
        }

        public async Task<Patient> AddAsync(Patient patient)
        {
            var _context = new PillsyDBContext();
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var accountId = Guid.NewGuid();
                patient.AccountId = accountId;
                patient.Account.AccountId = accountId;
                patient.Account.CreatedDate = DateTime.Now;
                patient.Account.LastModifiedDate = DateTime.Now;
                patient.Account.Status = 1;


                patient.CreatedBy = accountId;
                patient.CreatedDate = DateTime.Now;
                patient.LastModifiedDate = DateTime.Now;
                patient.ModifiedBy = accountId;
                await _context.Patients.AddAsync(patient);
                await _context.SaveChangesAsync();

                transaction.Commit();
                return patient;
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}
