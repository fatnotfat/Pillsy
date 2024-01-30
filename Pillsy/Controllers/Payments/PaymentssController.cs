using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pillsy.DataTransferObjects.Payment.PaymentDto;
using Service.Momo.Request;

namespace Pillsy.Controllers.Payments
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentssController : ControllerBase
    {
        //[HttpGet]
        //[Route("momo-return")]
        //public async Task<IActionResult> MomoReturn([FromQuery] MomoOneTimePaymentResultRequest response)
        //{
        //    string returnUrl = string.Empty;
        //    var returnModel = new PaymentReturnDto();
        //    var processResult = await response.Adapt<ProcessMomoPaymentReturn>();

        //    if (processResult.Success)
        //    {
        //        returnModel = processResult.Data.Item1 as PaymentReturnDto;
        //        returnUrl = processResult.Data.Item2 as string;
        //    }

        //    if (returnUrl.EndsWith("/"))
        //        returnUrl = returnUrl.Remove(returnUrl.Length - 1, 1);
        //    return Redirect($"{returnUrl}?{returnModel.ToQueryString()}");
        //}
    }
}
