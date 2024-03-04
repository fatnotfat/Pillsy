using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using Service.Interfaces;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace Pillsy.Controllers.SubscriptionPackages
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionPackagesController : ControllerBase
    {
        private readonly ISubscriptionPackageService _subscriptionPackageService;

        public SubscriptionPackagesController(ISubscriptionPackageService subscriptionPackageService)
        {
            _subscriptionPackageService = subscriptionPackageService;
        }


        // GET: api/SubscriptionPackages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubscriptionPackage>>> GetSubscriptionPackages()
        {
            return Ok(await _subscriptionPackageService.GetSubscriptionPackages());
        }

        // GET: api/SubscriptionPackages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubscriptionPackage>> GetSubscriptionPackage(Guid id)
        {

            var subscriptionPackage = await _subscriptionPackageService.GetSubscriptionPackageById(id);

            if (subscriptionPackage == null)
            {
                return NotFound();
            }

            return Ok(subscriptionPackage);
        }


    }
}
