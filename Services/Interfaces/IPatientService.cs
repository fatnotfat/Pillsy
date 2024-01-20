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
    }
}
