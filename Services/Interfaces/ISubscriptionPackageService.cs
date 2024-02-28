﻿using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ISubscriptionPackageService
    {
        public Task<SubscriptionPackage> GetSubscriptionPackageById(Guid subscriptionPackageId);
    }
}