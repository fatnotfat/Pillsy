using BusinessObject;
using MailKit.Search;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessObject
{
    public class OrderDAO
    {
        private static OrderDAO instance1 = null;
        private static SubscriptionPackageDAO instance2 = null;


        public static OrderDAO Instance
        {
            get
            {
                if (instance1 == null)
                {
                    instance1 = new OrderDAO();
                }
                return instance1;
            }
        }

        public static SubscriptionPackageDAO Instance2
        {
            get
            {
                if (instance2 == null)
                {
                    instance2 = new SubscriptionPackageDAO();
                }
                return instance2;
            }
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            try
            {
                var context = new PillsyDBContext();
                var result = await context.Orders!.Include(o => o.Patient).ToListAsync();
                foreach (var order in result)
                {
                    var patients = await context.Patients!.Include(p => p.Account).ToListAsync();
                    var patient = patients.FirstOrDefault(p => p.PatientID.Equals(order.PatientId));
                    order.Patient = patient;
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Order> GetOrderByOrderId(Guid orderId)
        {
            try
            {
                var context = new PillsyDBContext();
                var result = await context.Orders!.FirstOrDefaultAsync(o => o.OrderID.Equals(orderId));
                return result!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Order>> GetOrderByPatientId(Guid patientId)
        {
            try
            {
                var context = new PillsyDBContext();
                var result = await context.Orders!.Include(o => o.OrderDetails).Where(o => o.PatientId.Equals(patientId)).ToListAsync();
                foreach (var o in result)
                {
                    foreach (var o2 in o.OrderDetails)
                    {
                        var package = await Instance2.GetSubscriptionPackageByIdAsync((Guid)o2.SubscriptionId!);
                        o2.SubscriptionPackage = package;
                    }
                }
                return result!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Order> GetOrderByOrderIdPayOs(int orderIdPayOS)
        {
            try
            {
                var context = new PillsyDBContext();
                var result = await context.Orders!.FirstOrDefaultAsync(o => o.OrderId_PayOS.Equals(orderIdPayOS));
                return result!;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<bool> AddNewOrder(Order order)
        {
            try
            {
                var context = new PillsyDBContext();
                var result = context.Orders!.Add(order);
                await context.SaveChangesAsync();
                if (result != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<bool> UpdateOrder(Order order)
        {
            try
            {
                var context = new PillsyDBContext();
                var result = context.Orders!.Update(order);
                await context.SaveChangesAsync();
                if (result != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
