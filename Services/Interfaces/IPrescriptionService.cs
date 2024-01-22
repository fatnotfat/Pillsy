using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IPrescriptionService
    {
        public Task<IEnumerable<Prescription>> GetAllPrescriptionsAsync();
        public Task<Prescription> GetPrescriptionsByPrescriptionIdAsync(Guid prescriptionId);
        public Task<byte[]> AddAsync(Prescription prescription);
    }
}
