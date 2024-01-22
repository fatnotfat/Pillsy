
using BusinessObject;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IPrescriptionRepository _prescriptionRepository;
        public PrescriptionService(IPrescriptionRepository repo)
        {
            _prescriptionRepository = repo;
        }

        public async Task<byte[]> AddAsync(Prescription prescription)
        {
            return await _prescriptionRepository.AddAsync(prescription);
        }

        public async Task<IEnumerable<Prescription>> GetAllPrescriptionsAsync()
        {
            return await _prescriptionRepository.GetAllPrescriptionsAsync();
        }

        public async Task<Prescription> GetPrescriptionsByPrescriptionIdAsync(Guid prescriptionId)
        {
            return await _prescriptionRepository.GetPrescriptionsByPrescriptionIdAsync(prescriptionId);
        }
    }
}
