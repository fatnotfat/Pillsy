using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IOrderRepository
    {
        public Task<IEnumerable<Order>> GetOrder();
        public Task<bool> UpdateOrder(Order order);
        public Task<bool> AddNewOrder(Order order);
        public Task<Order> GetOrderByOrderId(Guid orderId);
        public Task<Order> GetOrderByOrderIdPayOs(int orderIdPayOs);
        public Task<Order> GetOrderByPatientId(Guid patientId);


    }
}
