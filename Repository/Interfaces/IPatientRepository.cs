using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IPatientRepository
    {
        public Task<IEnumerable<Patient>> GetPatients();
        public Task<Patient> GetById(Guid id);
        public Task<Patient> AddNew(Patient patient);
        public Task<bool> Update(Patient patient);
        public Task<Patient> GetByAccountId(Guid id);
        public Task<IEnumerable<Patient>> GetNewPatientsByMonthAsync(int month);
        public Task<IEnumerable<Patient>> GetNewPatientsByDateAsync(int date);
        public Task<IEnumerable<Patient>> GetNewPatientsByYearAsync(int year);

    }
}
