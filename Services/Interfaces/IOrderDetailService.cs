﻿using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IOrderDetailService
    {
        public Task<IEnumerable<OrderDetail>> GetOrderDetailsAsync();
        public Task<OrderDetail> GetOrderDetailByOrderDetailId(Guid orderDetailId);
        public Task<IEnumerable<OrderDetail>> GetOrderDetailByOrderId(Guid orderId);
        public Task<bool> AddNewOrderDetail(OrderDetail orderDetail);
        public Task<bool> UpdateOrderDetail(OrderDetail orderDetail);
    }
}
