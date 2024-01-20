
using BusinessObject;
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
        public Task<IEnumerable<Prescription>> GetAllPrescriptionsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Prescription> GetPrescriptionsByPrescriptionIdAsync(Guid prescriptionId)
        {
            throw new NotImplementedException();
        }
    }
}
