﻿namespace Pillsy.DataTransferObjects.Prescription.PrescriptionRequestOCRDto
{
    public class PrescriptionRequestOCRDto
    {
        public Guid? User_Id { get; set; }
        public Guid? Prescription_Id { get; set; }
        public string? Image { get; set; }
    }
}
