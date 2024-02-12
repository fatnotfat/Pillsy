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
    public class PillService : IPillService
    {
        private IPillRepository _repository;
        public PillService(IPillRepository repository)
        {
            _repository = repository;
        }

        public Pill AddPill(Pill pill)
        {
            try
            {
                var result = _repository.AddPill(pill);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Pill> AddPillAsync(Pill pill)
        {
            try
            {
                var result = await _repository.AddPillAsync(pill);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Pill>> GetAllPillsAsync()
        {
            try
            {
                var pills = await _repository.GetAllPillsAsync();
                return pills;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Pill>> GetPillsByPrescriptionIdAsync(Guid prescriptionId)
        {
            try
            {
                if ((prescriptionId.ToString().Length < 1))
                {
                    throw new Exception("Prescription id not null or empty!");
                }
                var pills = await _repository.GetPillsByPrescriptionIdAsync(prescriptionId);
                return pills;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
