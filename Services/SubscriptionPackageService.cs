﻿using BusinessObject;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class SubscriptionPackageService : ISubscriptionPackageService
    {
        private readonly ISubscriptionPackageRepository _repository;

        public SubscriptionPackageService(ISubscriptionPackageRepository repository)
        {
            _repository = repository;
        }

        public async Task<SubscriptionPackage> GetSubscriptionPackageById(Guid subscriptionPackageId)
        {
            return await _repository.GetSubscriptionPackageByIdAsync(subscriptionPackageId);
        }
    }
}
