using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessObject
{
    public class PrescriptionDAO
    {
        private static PrescriptionDAO instance = null;

        public static PrescriptionDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PrescriptionDAO();
                }
                return instance;
            }
        }

        public async Task<IEnumerable<Prescription>> GetAll()
        {
            try
            {
                var _context = new PillsyDBContext();
                var prescriptions = await _context.Prescriptions.ToListAsync();
                if (prescriptions == null)
                {
                    throw new Exception("No content found!");
                }
                return prescriptions;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Prescription> GetPrescriptionById(Guid prescriptionId)
        {
            try
            {
                var _context = new PillsyDBContext();
                var result = await GetAll();
                if (result.Count() < 1)
                {
                    throw new Exception("The list is empty!");
                }
                var prescription = await _context.Prescriptions.FirstOrDefaultAsync(p => p.PrescriptionID.Equals(prescriptionId));
                if (prescription == null)
                {
                    throw new Exception("No content found!");
                }
                return prescription;

            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<bool> AddAsync(Prescription prescription)
        {
            var _context = new PillsyDBContext();
            using var transaction = _context.Database.BeginTransaction();
            var result = false;
            try
            {
                _context.Prescriptions.AddAsync(prescription);
                await _context.SaveChangesAsync();

                transaction.Commit();
                result = true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
            return result;
        }
    }
}
