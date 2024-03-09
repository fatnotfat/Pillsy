using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IOrderService
    {
        public Task<IEnumerable<Order>> GetOrder();
        public Task<bool> UpdateOrder(Order order);
        public Task<bool> AddNewOrder(Order order);
        public Task<Order> GetOrderByOrderId(Guid orderId);
        public Task<Order> GetOrderByOrderIdPayOs(int orderIdPayOs);
        public Task<IEnumerable<Order>> GetOrderByPatientId(Guid patientId);

    }
}
