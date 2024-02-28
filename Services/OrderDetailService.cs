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
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        public OrderDetailService(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }
        public async Task<bool> AddNewOrderDetail(OrderDetail orderDetail)
        {
            return await _orderDetailRepository.AddNewOrderDetail(orderDetail);
        }

        public async Task<OrderDetail> GetOrderDetailByOrderDetailId(Guid orderDetailId)
        {
            return await _orderDetailRepository.GetOrderDetailByOrderDetailId(orderDetailId);
        }

        public async Task<IEnumerable<OrderDetail>> GetOrderDetailByOrderId(Guid orderId)
        {
            return await _orderDetailRepository.GetOrderDetailByOrderId(orderId);
        }

        public async Task<IEnumerable<OrderDetail>> GetOrderDetailsAsync()
        {
            return await _orderDetailRepository.GetOrderDetailsAsync();
        }

        public async Task<bool> UpdateOrderDetail(OrderDetail orderDetail)
        {
            return await _orderDetailRepository.UpdateOrderDetail(orderDetail);
        }
    }
}
