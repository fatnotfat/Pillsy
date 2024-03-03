using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessObject
{
    public class PaymentDAO
    {
        private static PaymentDAO instance = null;


        public static PaymentDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PaymentDAO();
                }
                return instance;
            }
        }

        public async Task<IEnumerable<Payment>> GetAllPayments()
        {
            var context = new PillsyDBContext();
            var payments = await context.Payments!.ToListAsync();
            return payments;
        }

        public async Task<Payment> GetPaymentByPaymentType(string paymentType)
        {
            var context = new PillsyDBContext();
            var payment = await context.Payments!.FirstOrDefaultAsync(p => p.PaymentType.Equals(paymentType.Trim()));
            return payment;
        }
    }
}
