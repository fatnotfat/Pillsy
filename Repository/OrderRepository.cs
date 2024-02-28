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
    public class OrderRepository : IOrderRepository
    {
        public async Task<bool> AddNewOrder(Order order)
        {
            return await OrderDAO.Instance.AddNewOrder(order);
        }

        public async Task<IEnumerable<Order>> GetOrder()
        {
            return await OrderDAO.Instance.GetOrders();
        }

        public async Task<Order> GetOrderByOrderId(Guid orderId)
        {
            return await OrderDAO.Instance.GetOrderByOrderId(orderId);
        }

        public async Task<Order> GetOrderByOrderIdPayOs(int orderIdPayOs)
        {
            return await OrderDAO.Instance.GetOrderByOrderIdPayOs(orderIdPayOs);
        }

        public async Task<bool> UpdateOrder(Order order)
        {
            return await OrderDAO.Instance.UpdateOrder(order);
        }
    }
}
