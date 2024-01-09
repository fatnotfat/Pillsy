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

        private static PatientDAO instance = null;

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

        public async Task<IEnumerable<Patient>> GetPatients()
        {
            var _context = new PillsyDBContext();
            var result = await _context.Patients.ToListAsync();
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public async Task<Patient> GetPatientById(Guid patientId)
        {
            var _context = new PillsyDBContext();
            return await _context.Patients.FirstOrDefaultAsync(a => a.PatientID.Equals(patientId));
        }

        public async Task<Patient> Add(Patient patient)
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
                _context.Patients.AddAsync(patient);
                await _context.SaveChangesAsync();

                transaction.Commit();
                return patient;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return null;
            }
        }
    }
}
