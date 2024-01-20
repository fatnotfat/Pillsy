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
        private static PillDAO instance = null;

        public static PillDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PillDAO();
                }
                return instance;
            }
        }

        public async Task<IEnumerable<Pill>> GetAll()
        {
            try
            {
                var _context = new PillsyDBContext();
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
                var _context = new PillsyDBContext();
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

    }
}
