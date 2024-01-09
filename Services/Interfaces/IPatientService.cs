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
        Task<IEnumerable<Patient>> GetAllPatients();
        Task<Patient> GetPatientById(Guid id);
        Task<Patient> AddNewPatient(Patient patient);
    }
}
