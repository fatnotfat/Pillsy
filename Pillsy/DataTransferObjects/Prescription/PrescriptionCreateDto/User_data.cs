﻿using Pillsy.DataTransferObjects.Prescription.PrescriptionCreateDto;

namespace Pillsy.DataTransferObjects.Prescription.PrescriptionCreateDto
{
    public class User_data
    {
        public Guid Medication_records_id { get; set; }
        public Medication_records Medication_records { get; set; }
        public Meta_data? Meta_data { get; set; }

    }
}
