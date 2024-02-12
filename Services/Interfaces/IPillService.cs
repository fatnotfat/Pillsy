using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IPillService
    {
        public Task<IEnumerable<Pill>> GetAllPillsAsync();
        public Task<IEnumerable<Pill>> GetPillsByPrescriptionIdAsync(Guid prescriptionId);
        public Task<Pill> AddPillAsync(Pill pill);
        public Pill AddPill(Pill pill);

    }
}
