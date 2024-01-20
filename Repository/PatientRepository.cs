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
                var result = await patientDAO.AddAsync(patient);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Patient> GetById(Guid id)
        {
            try
            {
                var result = await patientDAO.GetPatientByIdAsync(id);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Patient>> GetPatients()
        {
            try
            {
                return await patientDAO.GetPatientsAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Update(Patient patient)
        {
            try
            {
                return await patientDAO.UpdatePatientAsync(patient);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
