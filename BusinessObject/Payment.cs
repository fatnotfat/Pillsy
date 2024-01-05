﻿using BusinessObject.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Payment : BaseEntity
    {
        public Guid PaymentId { get; set; }
        public string PaymentType { get; set; }
        public int Status { get; set; }
        public List<Patient> Patients { get; set; }
    }
}
