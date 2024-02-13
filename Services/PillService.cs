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
        private IPrescriptionRepository _prescriptionRepository;
        public PillService(IPillRepository repository, IPrescriptionRepository prescriptionRepository)
        {
            _repository = repository;
            _prescriptionRepository = prescriptionRepository;
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

        public async Task<bool> AddPillToPrescription(Pill pill, Guid prescriptionId)
        {
            var result = false;
            try
            {
                var prescription = await _prescriptionRepository.GetPrescriptionsByPrescriptionIdAsync(prescriptionId);
                if (prescription != null)
                {
                    pill.PrescriptionId = prescriptionId;
                    result = await _repository.AddPillToPrescription(pill);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
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

        public async Task<Pill> GetPillByIdAsync(Guid pillId)
        {
            try
            {
                var pill = await _repository.GetPillByIdAsync(pillId);
                return pill;
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

        public async Task<bool> UpdatePillAsync(Guid pillId, Pill pill)
        {
            var result = false;
            try
            {
                if (pill == null)
                {
                    throw new Exception("Content must not be empty!");
                }
                else
                {
                    var pillExisted = await _repository.GetPillByIdAsync(pillId);
                    if (pillExisted != null)
                    {
                        result = await _repository.UpdatePillAsync(pill);
                    }
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
