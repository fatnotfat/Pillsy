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
    public class CustomerPackageRepository : ICustomerPackageRepository
    {
        private readonly CustomerPackageDAO customerPackageDAO;

        public CustomerPackageRepository()
        {
            customerPackageDAO = new CustomerPackageDAO();
        }

        public async Task<bool> AddNewCustomerPackage(CustomerPackage customerPackage)
        {
            return await customerPackageDAO.AddNewCustomerPackage(customerPackage);
        }

        public async Task<CustomerPackage> GetCustomerPackageByCustomerPackageId(Guid customerPackageId)
        {
            return await customerPackageDAO.GetCustomerPackageByCustomerPackageId(customerPackageId);
        }

        public async Task<IEnumerable<CustomerPackage>> GetCustomerPackages()
        {
            return await customerPackageDAO.GetCustomerPackages();
        }

        public async Task<bool> UpdateCustomerPackage(CustomerPackage customerPackage)
        {
            return await customerPackageDAO.UpdateCustomerPackage(customerPackage);
        }
    }
}
