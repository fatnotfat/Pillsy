using BusinessObject;
using DataAcessObject;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CustomerPackageService : ICustomerPackageService
    {
        private readonly ICustomerPackageRepository _customerPackageRepository;
        public CustomerPackageService(ICustomerPackageRepository customerPackageRepository)
        {
            _customerPackageRepository = customerPackageRepository;
        }
        public async Task<bool> AddNewCustomerPackage(CustomerPackage customerPackage)
        {
            return await _customerPackageRepository.AddNewCustomerPackage(customerPackage);
        }

        public async Task<CustomerPackage> GetCustomerPackageByCustomerPackageId(Guid customerPackageId)
        {
            return await _customerPackageRepository.GetCustomerPackageByCustomerPackageId(customerPackageId);
        }

        public async Task<CustomerPackage> GetCustomerPackageByPatientId(Guid patientId)
        {
            return await _customerPackageRepository.GetCustomerPackageByPatientId(patientId);
        }

        public async Task<IEnumerable<CustomerPackage>> GetCustomerPackages()
        {
            return await _customerPackageRepository.GetCustomerPackages();
        }

        public async Task<IEnumerable<CustomerPackage>> GetListCustomerPackageByPatientId(Guid patientId)
        {
            return await _customerPackageRepository.GetListCustomerPackageByPatientId(patientId);
        }

        public async Task<bool> UpdateCustomerPackage(CustomerPackage customerPackage)
        {
            return await _customerPackageRepository.UpdateCustomerPackage(customerPackage);
        }
    }
}
