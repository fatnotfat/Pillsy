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
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private readonly PrescriptionDAO prescriptionDAO;
        public PrescriptionRepository()
        {
            prescriptionDAO = new PrescriptionDAO();
        }

        public async Task<byte[]> AddAsync(Prescription prescription)
        {
            return await prescriptionDAO.AddAsync(prescription);
        }

        public async Task<IEnumerable<Prescription>> GetAllPrescriptionsAsync()
        {
            return await prescriptionDAO.GetAll();
        }

        public async Task<Prescription> GetPrescriptionsByPrescriptionIdAsync(Guid prescriptionId)
        {
            return await prescriptionDAO.GetPrescriptionById(prescriptionId);
        }

        public async Task<Prescription> UpdatePrescriptionAsync(Prescription prescription)
        {
            return await prescriptionDAO.UpdatePrescription(prescription);
        }
    }
}
