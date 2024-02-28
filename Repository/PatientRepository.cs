using BusinessObject;
using DataAcessObject;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public async Task<Patient> GetByAccountId(Guid id)
        {
            try
            {
                var result = await patientDAO.GetPatientByAccountIdAsync(id);
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

        public async Task<IEnumerable<Patient>> GetNewPatientsByDateAsync(int date)
        {
            try
            {
                return await patientDAO.GetNewPatientsByDateAsync(date);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Patient>> GetNewPatientsByMonthAsync(int month)
        {
            try
            {
                return await patientDAO.GetNewPatientsByMonthAsync(month);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Patient>> GetNewPatientsByYearAsync(int year)
        {
            try
            {
                return await patientDAO.GetNewPatientsByYearAsync(year);
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
