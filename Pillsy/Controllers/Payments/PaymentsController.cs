using BusinessObject;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Net.payOS;
using Net.payOS.Types;
using Newtonsoft.Json;
using NuGet.Common;
using Pillsy.DataTransferObjects.CustomerPackageDto;
using Pillsy.DataTransferObjects.Payment;
using Pillsy.DataTransferObjects.Payment.PaymentDto;
using Pillsy.DataTransferObjects.Pill.PillCreateWithPrescriptionDto;
using Pillsy.DataTransferObjects.Prescription.PrescriptionRequestOCRDto;
using Service.Interfaces;
using Service.Momo.Request;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Transactions;

namespace Pillsy.Controllers.Payments
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly ISubscriptionPackageService _subscriptionPackageService;
        private readonly IConfiguration _configuration;
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly ICustomerPackageService _customerPackageService;
        PayOS payOS;
        public PaymentsController(ISubscriptionPackageService subscriptionPackageService, IConfiguration configuration, IOrderService orderService, IOrderDetailService orderDetailService, ICustomerPackageService customerPackageService)
        {
            payOS = new PayOS(Constants.Constants.ClientId, Constants.Constants.ApiKey, Constants.Constants.CheckSumKey);
            _subscriptionPackageService = subscriptionPackageService;
            _configuration = configuration;
            _orderService = orderService;
            _orderDetailService = orderDetailService;
            _customerPackageService = customerPackageService;
        }

        [Authorize(Roles = "Patient")]
        [HttpPost]
        [Route("bank-transfer")]
        public async Task<ActionResult<bool>> BankTransfer(string name, int number, int price, Guid subscriptionId)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {

                    ItemData item = new ItemData(name, number, price);
                    List<ItemData> items = new List<ItemData>();
                    items.Add(item);

                    var description = "Thanh toan chuyen khoan";
                    Random rnd = new Random();
                    var orderId = rnd.Next(0, 1000000000);
                    var totalPrice = price;

                    string patientId = User.FindFirst("PatientId")?.Value;






                    PaymentData paymentData = new PaymentData(orderId, totalPrice, description, items, "https://localhost:7100/", "https://localhost:7100/");
                    CreatePaymentResult createPayment = await payOS.createPaymentLink(paymentData);

                    var linkCheckOut = createPayment.checkoutUrl;
                    PaymentResponsePayOSDTO paymentResponsePayOSDTO = new PaymentResponsePayOSDTO
                    {
                        OrderId = orderId.ToString(),
                        LinkCheckout = linkCheckOut
                    };

                    Order order = new Order
                    {
                        OrderID = Guid.NewGuid(),
                        TotalPrice = totalPrice,
                        TotalItem = number,
                        Status = false,
                        OrderId_PayOS = orderId,
                        PatientId = Guid.Parse(patientId),
                        CreatedDate = DateTime.UtcNow,
                        CreatedBy = null,
                        LastModifiedDate = DateTime.UtcNow,
                        ModifiedBy = null,
                    };
                    var subscriptionPackage = await _subscriptionPackageService.GetSubscriptionPackageById(subscriptionId);
                    if (subscriptionPackage == null)
                    {
                        return NotFound("Subscription package does not exist!");
                    }
                    OrderDetail orderDetail = new OrderDetail
                    {
                        OrderDetailID = Guid.NewGuid(),
                        Quantity = number,
                        Amount = price,
                        SubscriptionId = subscriptionPackage.SubscriptionId,
                        OrderID = order.OrderID,
                        CreatedDate = DateTime.Now,
                        CreatedBy = null,
                        LastModifiedDate = DateTime.Now,
                        ModifiedBy = null,
                    };

                    if (await _orderService.AddNewOrder(order))
                    {
                        await _orderDetailService.AddNewOrderDetail(orderDetail);
                        CustomerPackage customerPackage = new CustomerPackage();
                        if (subscriptionPackage.PackageType.Equals("Basic"))
                        {
                            customerPackage = new CustomerPackage
                            {
                                CustomerPackageName = subscriptionPackage.PackageType,
                                AllowPillHistory = 0,
                                DateEnd = DateTime.UtcNow.AddDays(30),
                                DateStart = DateTime.UtcNow,
                                NumberScan = "2",
                                PatientId = Guid.Parse(patientId),
                                Status = 0,
                                SubcriptionPackageId = subscriptionId
                            };
                        }
                        else
                        {
                            customerPackage = new CustomerPackage
                            {
                                CustomerPackageName = subscriptionPackage.PackageType,
                                AllowPillHistory = 1,
                                DateEnd = DateTime.UtcNow.AddDays(90),
                                DateStart = DateTime.UtcNow,
                                NumberScan = "Infinity",
                                PatientId = Guid.Parse(patientId),
                                Status = 0,
                                SubcriptionPackageId = subscriptionId
                            };
                        }
                        await _customerPackageService.AddNewCustomerPackage(customerPackage);
                    };


                    scope.Complete();
                    return Ok(paymentResponsePayOSDTO);

                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    return BadRequest(ex.Message);
                }
            }

        }

        [Authorize(Roles = "Patient")]
        [HttpGet]
        [Route("check-order")]
        public async Task<ActionResult<bool>> CheckOrder(int orderId)
        {
            try
            {
                
                PayOS payOS = new PayOS(Constants.Constants.ClientId, Constants.Constants.ApiKey, Constants.Constants.CheckSumKey);

                PaymentLinkInformation paymentLinkInfomation = await payOS.getPaymentLinkInfomation(orderId);
                return Ok(paymentLinkInfomation);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
