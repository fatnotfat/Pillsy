using BusinessObject;
using DataAcessObject;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PatientRepository : IPatientRepository
    {
        private PatientDAO patientDAO;
        public PatientRepository()
        {
            patientDAO = new PatientDAO();
        }

        public async Task<Patient> AddNew(Patient patient)
        {
            try
            {
                var result = await patientDAO.Add(patient);
                if (result != null)
                {
                    return result;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<Patient> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await patientDAO.GetPatients();
        }
    }
}
