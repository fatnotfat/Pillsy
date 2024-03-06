using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Pillsy.DataTransferObjects.Order.AddNewOrderDto;

namespace Pillsy.Controllers.Orders
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [Authorize(Roles = "Admin")]
        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {

            return Ok(await _orderService.GetOrder());
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(Guid id)
        {
            var order = await _orderService.GetOrderByOrderId(id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(Guid id)
        {

            try
            {
                var order = await _orderService.GetOrderByOrderId(id);
                if (order == null)
                {
                    return NotFound("Order not found!");
                }
                else
                {
                    order.Status = true;
                    var result = await _orderService.UpdateOrder(order);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Order update successfully!");
        }

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<string>> AddNewOrder(AddNewOrderDto newOrderDto)
        {
            try
            {
                Random random = new Random();
                int orderPayOsId = random.Next(1, 2000000000);
                var orderExisted = await _orderService.GetOrderByOrderIdPayOs(orderPayOsId);
                if (orderExisted != null)
                {
                    return BadRequest("Order PayOs Id was exist!, Please try again!");
                }
                string userId = User.FindFirst("AccountId")?.Value;
                var order = new Order
                {
                    OrderID = Guid.NewGuid(),
                    TotalItem = newOrderDto.TotalItem,
                    TotalPrice = newOrderDto.TotalPrice,
                    OrderId_PayOS = orderPayOsId,
                    CreatedBy = Guid.Parse(userId),
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now,
                    ModifiedBy = Guid.Parse(userId),
                    Status = newOrderDto.Status,
                };
                var result = await _orderService.AddNewOrder(order);
                if (result)
                {
                    return Ok("Add successfully!");
                }
                else
                {
                    return BadRequest("Add failed!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
