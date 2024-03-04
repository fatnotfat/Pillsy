using BusinessObject;
using DataAcessObject;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SubscriptionPackageRepository : ISubscriptionPackageRepository
    {
        public async Task<SubscriptionPackage> GetSubscriptionPackageByIdAsync(Guid subscriptionPackageId)
        {
            return await SubscriptionPackageDAO.Instance.GetSubscriptionPackageByIdAsync(subscriptionPackageId);
        }

        public async Task<IEnumerable<SubscriptionPackage>> GetSubscriptionPackages()
        {
            return await SubscriptionPackageDAO.Instance.GetSubscriptionPackages();
        }
    }
}
