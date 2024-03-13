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
using Microsoft.AspNetCore.Authorization;

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
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerPackage>>> GetCustomerPackages()
        {
            return Ok(await _customerPackageService.GetCustomerPackages());
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("totals")]
        public async Task<ActionResult<IEnumerable<CustomerPackage>>> GetCustomerPackagesTotals()
        {
            var customerPackages = await _customerPackageService.GetCustomerPackages();
            int totals = customerPackages.Where(c => c.Status == 1).Count();
            return Ok(totals);
        }

        // GET: api/CustomerPackages/5
        [Authorize(Roles = "Patient")]
        [HttpGet]
        [Route("patient/{patinetId}")]
        public async Task<ActionResult<CustomerPackage>> GetCustomerPackageByPatientId(Guid patientId)
        {

            var customerPackage = await _customerPackageService.GetCustomerPackageByPatientId(patientId);

            if (customerPackage == null)
            {
                return NotFound();
            }

            return Ok(customerPackage);
        }

        // PUT: api/CustomerPackages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<CustomerPackage>> AddCustomerPackage(CustomerPackage customerPackage)
        {
            await _customerPackageService.AddNewCustomerPackage(customerPackage);

            return Ok("Add successfully!");
        }
    }
}
