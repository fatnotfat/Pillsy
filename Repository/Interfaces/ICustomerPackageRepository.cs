using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ICustomerPackageRepository
    {
        public Task<bool> AddNewCustomerPackage(CustomerPackage customerPackage);
        public Task<bool> UpdateCustomerPackage(CustomerPackage customerPackage);
        public Task<CustomerPackage> GetCustomerPackageByCustomerPackageId(Guid customerPackageId);
        public Task<IEnumerable<CustomerPackage>> GetCustomerPackages();
        public Task<CustomerPackage> GetCustomerPackageByPatientId(Guid patientId);
        public Task<IEnumerable<CustomerPackage>> GetListCustomerPackageByPatientId(Guid patientId);
        public Task<bool> DeleteCustomerPackage(CustomerPackage customerPackage);


    }
}
