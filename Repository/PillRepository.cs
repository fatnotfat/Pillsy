using BusinessObject;
using DataAcessObject;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PillRepository : IPillRepository
    {
        private readonly PillDAO pillDAO;
        public PillRepository()
        {
            pillDAO = new PillDAO();
        }

        public Pill AddPill(Pill pill)
        {
            return pillDAO.Add(pill);
        }

        public async Task<Pill> AddPillAsync(Pill pill)
        {
            return await pillDAO.AddAsync(pill);
        }

        public async Task<bool> AddPillToPrescription(Pill pill)
        {
            return await pillDAO.AddPillToPrescription(pill);
        }

        public async Task<IEnumerable<Pill>> GetAllPillsAsync()
        {
            return await pillDAO.GetAll();
        }

        public async Task<Pill> GetPillByIdAsync(Guid pillId)
        {
            return await pillDAO.GetPillByIdAsync(pillId);
        }

        public async Task<IEnumerable<Pill>> GetPillsByPrescriptionIdAsync(Guid prescriptionId)
        {
            return await pillDAO.GetAllByPrescriptionId(prescriptionId);
        }

        public async Task<bool> UpdatePillAsync(Pill pill)
        {
            return await pillDAO.UpdatePillAsync(pill);
        }
    }
}
