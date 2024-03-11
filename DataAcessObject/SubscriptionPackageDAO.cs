using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessObject
{
    public class SubscriptionPackageDAO
    {
        private static SubscriptionPackageDAO instance = null;


        public static SubscriptionPackageDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SubscriptionPackageDAO();
                }
                return instance;
            }
        }

        public async Task<SubscriptionPackage> GetSubscriptionPackageByIdAsync(Guid subscriptionPackageId)
        {
            try
            {
                var context = new PillsyDBContext();
                var subscriptionPackage = await context.SubscriptionPackages!.FirstOrDefaultAsync(s => s.SubscriptionId.Equals(subscriptionPackageId));
                return subscriptionPackage;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<SubscriptionPackage>> GetSubscriptionPackages()
        {
            try
            {
                var context = new PillsyDBContext();
                var subscriptionPackages = await context.SubscriptionPackages!.ToListAsync();
                return subscriptionPackages;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<SubscriptionPackage> GetSubscriptionPackageByNameAsync(string name)
        {
            try
            {
                var context = new PillsyDBContext();
                var subscriptionPackage = await context.SubscriptionPackages.FirstOrDefaultAsync(s => s.PackageType.Contains(name.ToUpper()));
                return subscriptionPackage;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
