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
        private static OrderDAO instance = null;


        public static OrderDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OrderDAO();
                }
                return instance;
            }
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            try
            {
                var context = new PillsyDBContext();
                var result = await context.Orders!.ToListAsync();
                return result;
            }catch (Exception)
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

        public async Task<Order> GetOrderByPatientId(Guid patientId)
        {
            try
            {
                var context = new PillsyDBContext();
                var result = await context.Orders!.FirstOrDefaultAsync(o => o.PatientId.Equals(patientId));
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
                if(result != null)
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
