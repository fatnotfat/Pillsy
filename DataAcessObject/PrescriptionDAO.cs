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
        private readonly PillsyDBContext _context;
        public PrescriptionDAO()
        {
            _context = new PillsyDBContext();
        }

        public async Task<IEnumerable<Prescription>> GetAll()
        {
            try
            {
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

        public async Task<Prescription> UpdatePrescription(Prescription prescription)
        {
            try
            {
                var result = await GetAll();
                if (result.Count() < 1)
                {
                    throw new Exception("The list is empty!");
                }
                var prescriptionExist = await _context.Prescriptions.FirstOrDefaultAsync(p => p.PrescriptionID.Equals(prescription.PrescriptionID));
                if (prescriptionExist == null)
                {
                    throw new Exception("No content found!");
                }
                _context.Entry(prescription).State = EntityState.Modified;
                //_context.Entry(prescription).CurrentValues.SetValues(prescription);
                await _context.SaveChangesAsync();
                return prescription;

            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<byte[]> AddAsync(Prescription prescription)
        {
            try
            {
                await _context.AddAsync(prescription);
                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {
                throw;
            }
            return prescription.ImageBase64;
        }


        public async Task<IEnumerable<Prescription>> GetPrescriptionByPatientId(Guid prescriptionId)
        {
            try
            {
                var result = await GetAll();
                if (result.Count() < 1)
                {
                    throw new Exception("The list is empty!");
                }
                var prescription = await _context.Prescriptions.Include(p => p.Pills).Where(p => p.PatientID.Equals(prescriptionId)).ToListAsync();
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
    }
}
