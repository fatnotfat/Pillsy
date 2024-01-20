﻿using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IPillRepository
    {
        public Task<IEnumerable<Pill>> GetAllPillsAsync();
        public Task<IEnumerable<Pill>> GetPillsByPrescriptionIdAsync(Guid prescriptionId);
    }
}