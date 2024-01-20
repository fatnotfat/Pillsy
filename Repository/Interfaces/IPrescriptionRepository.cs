﻿using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IPrescriptionRepository
    {
        public Task<IEnumerable<Prescription>> GetAllPrescriptionsAsync();
        public Task<Prescription> GetPrescriptionsByPrescriptionIdAsync(Guid prescriptionId);
    }
}
