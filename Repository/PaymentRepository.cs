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
    public class PaymentRepository : IPaymentRepository
    {
        public async Task<IEnumerable<Payment>> GetAllPayments()
        {
            return await PaymentDAO.Instance.GetAllPayments();
        }

        public async Task<Payment> GetPaymentByPaymentType(string paymentType)
        {
            return await PaymentDAO.Instance.GetPaymentByPaymentType(paymentType);
        }
    }
}
