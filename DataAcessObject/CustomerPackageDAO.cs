using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessObject
{
    public class CustomerPackageDAO
    {
        private static CustomerPackageDAO instance = null;


        public static CustomerPackageDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CustomerPackageDAO();
                }
                return instance;
            }
        }

        public async Task<IEnumerable<CustomerPackage>> GetCustomerPackages()
        {
            try
            {
                var context = new PillsyDBContext();
                return await context.CustomerPackages!.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CustomerPackage> GetCustomerPackageByCustomerPackageId(Guid customerPackageId)
        {
            try
            {
                var context = new PillsyDBContext();
                return await context.CustomerPackages!.FirstOrDefaultAsync(c => c.CustomerPackageId.Equals(customerPackageId));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CustomerPackage> GetCustomerPackageByPatientId(Guid patientId)
        {
            try
            {
                var context = new PillsyDBContext();
                return await context.CustomerPackages!.Include(c => c.SubscriptionPackage).OrderByDescending(c => c.CreatedDate).FirstOrDefaultAsync(c => c.PatientId.Equals(patientId));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> AddNewCustomerPackage(CustomerPackage customerPackage)
        {
            try
            {
                var result = false;
                var context = new PillsyDBContext();
                var value = context.CustomerPackages!.Add(customerPackage);
                if (value != null)
                {
                    result = true;
                }
                await context.SaveChangesAsync();
                return result;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<bool> UpdateCustomerPackage(CustomerPackage customerPackage)
        {
            try
            {
                var result = false;
                var context = new PillsyDBContext();
                var value = context.CustomerPackages.Update(customerPackage);
                if (value != null)
                {
                    result = true;
                }
                await context.SaveChangesAsync();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
