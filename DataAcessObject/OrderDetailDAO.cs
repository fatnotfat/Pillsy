using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessObject
{
    public class OrderDetailDAO
    {
        private static OrderDetailDAO instance = null;


        public static OrderDetailDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OrderDetailDAO();
                }
                return instance;
            }
        }

        public async Task<IEnumerable<OrderDetail>> GetOrderDetails()
        {
            try
            {
                var context = new PillsyDBContext();
                var result = await context.OrderDetails!.ToListAsync();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<OrderDetail> GetOrderDetailByOrderDetailId(Guid orderDetailId)
        {
            try
            {
                var context = new PillsyDBContext();
                var result = await context.OrderDetails!.FirstOrDefaultAsync(o => o.OrderDetailID.Equals(orderDetailId));
                return result!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<OrderDetail>> GetOrderDetailByOrderId(Guid orderId)
        {
            try
            {
                var context = new PillsyDBContext();
                var result = await context.OrderDetails!.Where(o => o.OrderID.Equals(orderId)).ToListAsync();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<bool> AddNewOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                var context = new PillsyDBContext();
                var result = context.OrderDetails!.Add(orderDetail);
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


        public async Task<bool> UpdateOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                var context = new PillsyDBContext();
                var result = context.OrderDetails!.Update(orderDetail);
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
