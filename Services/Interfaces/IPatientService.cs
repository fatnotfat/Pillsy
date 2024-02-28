using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IPatientService
    {
        public Task<IEnumerable<Patient>> GetAllPatients();
        public Task<Patient> GetPatientById(Guid id);
        public Task<Patient> AddNewPatient(Patient patient);
        public Task<bool> UpdatePatientAsync(Patient patient);
        public Task<Patient> GetPatientByAccountIdAsync(Guid id);
        public Task<IEnumerable<Patient>> GetNewPatientsByMonthAsync(int month);
        public Task<IEnumerable<Patient>> GetNewPatientsByDateAsync(int date);
        public Task<IEnumerable<Patient>> GetNewPatientsByYearAsync(int year);
    }
}
