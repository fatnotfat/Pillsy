using BusinessObject;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Net.payOS;
using Net.payOS.Types;
using Pillsy.DataTransferObjects.Payment.PaymentDto;
using Pillsy.DataTransferObjects.Pill.PillCreateWithPrescriptionDto;
using Service.Momo.Request;
using System.Diagnostics;

namespace Pillsy.Controllers.Payments
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        PayOS payOS;
        public PaymentsController()
        {
            payOS = new PayOS(Constants.Constants.ClientId, Constants.Constants.ApiKey, Constants.Constants.CheckSumKey);
        }

        [Authorize(Roles = "Patient")]
        [HttpPost]
        [Route("bank-transfer")]
        public async Task<ActionResult<bool>> BankTransfer(string name, int number, int price)
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

                PaymentData paymentData = new PaymentData(orderId, totalPrice, description, items, "https://localhost:7100/", "https://localhost:7100/");
                CreatePaymentResult createPayment = await payOS.createPaymentLink(paymentData);

                var linkCheckOut = createPayment.checkoutUrl;
                Process.Start(new ProcessStartInfo
                {
                    FileName = @"C:\Program Files\Google\Chrome\Application\chrome.exe",
                    Arguments = linkCheckOut
                });
                return Ok(linkCheckOut);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
