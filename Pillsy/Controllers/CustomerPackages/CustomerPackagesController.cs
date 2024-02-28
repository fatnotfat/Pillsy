using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using Service.Interfaces;
using MailKit.Search;
using Net.payOS.Types;
using Net.payOS;

namespace Pillsy.Controllers.CustomerPackages
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerPackagesController : ControllerBase
    {
        private readonly ICustomerPackageService _customerPackageService;
        private readonly IOrderService _orderService;

        public CustomerPackagesController(ICustomerPackageService customerPackageService, IOrderService orderService)
        {
            _customerPackageService = customerPackageService;
            _orderService = orderService;
        }

        // GET: api/CustomerPackages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerPackage>>> GetCustomerPackages()
        {
            return Ok(await _customerPackageService.GetCustomerPackages());
        }

        //// GET: api/CustomerPackages/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<CustomerPackage>> GetCustomerPackage(Guid id)
        //{
        //  if (_context.CustomerPackages == null)
        //  {
        //      return NotFound();
        //  }
        //    var customerPackage = await _context.CustomerPackages.FindAsync(id);

        //    if (customerPackage == null)
        //    {
        //        return NotFound();
        //    }

        //    return customerPackage;
        //}

        // PUT: api/CustomerPackages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Route("update-success-status/{customerPackageId}/{orderId}")]
        public async Task<IActionResult> UpdateCustomerPackage(Guid customerPackageId, Guid orderId)
        {
            try
            {
                PayOS payOS = new PayOS(Constants.Constants.ClientId, Constants.Constants.ApiKey, Constants.Constants.CheckSumKey);
                var order = await _orderService.GetOrderByOrderId(orderId);
                if (order != null)
                {
                    PaymentLinkInformation paymentLinkInfomation = await payOS.getPaymentLinkInfomation((int)order.OrderId_PayOS!);
                    if (paymentLinkInfomation != null && paymentLinkInfomation.status.Equals("PAID"))
                    {
                        var customerPackage = await _customerPackageService.GetCustomerPackageByCustomerPackageId(customerPackageId);
                        if (customerPackage != null)
                        {
                            customerPackage.Status = 1;
                            await _customerPackageService.UpdateCustomerPackage(customerPackage);
                        }
                        else
                        {
                            return NotFound("Customer package not found!");
                        }
                    }
                    else
                    {
                        return BadRequest("Can not update because the user still not paid for the subscription!");
                    }

                }
                else
                {
                    return NotFound("Order not found!");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Update successfully!");
        }

        // POST: api/CustomerPackages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustomerPackage>> AddCustomerPackage(CustomerPackage customerPackage)
        {
            //if (_context.CustomerPackages == null)
            //{
            //    return Problem("Entity set 'PillsyDBContext.CustomerPackages'  is null.");
            //}
            await _customerPackageService.AddNewCustomerPackage(customerPackage);

            return Ok("Add successfully!");
        }

        //// DELETE: api/CustomerPackages/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCustomerPackage(Guid id)
        //{
        //    if (_context.CustomerPackages == null)
        //    {
        //        return NotFound();
        //    }
        //    var customerPackage = await _context.CustomerPackages.FindAsync(id);
        //    if (customerPackage == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.CustomerPackages.Remove(customerPackage);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool CustomerPackageExists(Guid id)
        //{
        //    return (_context.CustomerPackages?.Any(e => e.CustomerPackageId == id)).GetValueOrDefault();
        //}
    }
}
