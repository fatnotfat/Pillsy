using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IPaymentRepository
    {
        public Task<Payment> GetPaymentByPaymentType(string paymentType);
        public Task<IEnumerable<Payment>> GetAllPayments();


    }
}
