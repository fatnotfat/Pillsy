using BusinessObject;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<bool> AddNewOrder(Order order)
        {
            if ((await GetOrderByOrderIdPayOs((int)order.OrderId_PayOS!)) != null)
            {
                return false;
            }
            return await _orderRepository.AddNewOrder(order);
        }

        public async Task<IEnumerable<Order>> GetOrder()
        {
            return await _orderRepository.GetOrder();
        }

        public async Task<Order> GetOrderByOrderId(Guid orderId)
        {
            return await _orderRepository.GetOrderByOrderId(orderId);
        }

        public async Task<Order> GetOrderByOrderIdPayOs(int orderIdPayOs)
        {
            return await _orderRepository.GetOrderByOrderIdPayOs(orderIdPayOs);
        }

        public async Task<IEnumerable<Order>> GetOrderByPatientId(Guid patientId)
        {
            return await _orderRepository.GetOrderByPatientId(patientId);
        }

        public async Task<bool> UpdateOrder(Order order)
        {
            return await _orderRepository.UpdateOrder(order);
        }
    }
}
