using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessObject
{
    public class PillDAO
    {
        private readonly PillsyDBContext _context;
        public PillDAO()
        {

            _context = new PillsyDBContext();

        }

        public async Task<IEnumerable<Pill>> GetAll()
        {
            try
            {
                var pills = await _context.Pills.ToListAsync();
                if (pills == null)
                {
                    throw new Exception("No content found!");
                }
                return pills;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Pill>> GetAllByPrescriptionId(Guid prescriptionId)
        {
            try
            {
                var result = await GetAll();
                if (result.Count() < 1)
                {
                    throw new Exception("The list is empty!");
                }
                var pills = await _context.Pills.Where(p => p.PrescriptionId.Equals(prescriptionId)).ToListAsync();
                if (pills == null)
                {
                    throw new Exception("No content found!");
                }
                return pills;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Pill> AddAsync(Pill pill)
        {
            try
            {
                await _context.AddAsync(pill);
                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {
                throw;
            }
            return pill;
        }

        public Pill Add(Pill pill)
        {
            try
            {
                _context.AddAsync(pill);
                _context.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
            return pill;
        }

    }
}
