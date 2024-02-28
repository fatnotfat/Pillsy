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
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public async Task<bool> AddNewOrderDetail(OrderDetail orderDetail)
        {
            return await OrderDetailDAO.Instance.AddNewOrderDetail(orderDetail);
        }

        public async Task<OrderDetail> GetOrderDetailByOrderDetailId(Guid orderDetailId)
        {
            return await OrderDetailDAO.Instance.GetOrderDetailByOrderDetailId(orderDetailId);
        }

        public async Task<IEnumerable<OrderDetail>> GetOrderDetailByOrderId(Guid orderId)
        {
            return await OrderDetailDAO.Instance.GetOrderDetailByOrderId(orderId);
        }

        public async Task<IEnumerable<OrderDetail>> GetOrderDetailsAsync()
        {
            return await OrderDetailDAO.Instance.GetOrderDetails();
        }

        public async Task<bool> UpdateOrderDetail(OrderDetail orderDetail)
        {
            return await OrderDetailDAO.Instance.UpdateOrderDetail(orderDetail);
        }
    }
}
