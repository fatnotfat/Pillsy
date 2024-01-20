using BusinessObject.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Appointment : BaseEntity
    {
        public Guid AppointmentID { get; set; }
        public Guid PatientID { get; set; }
        public Guid DoctorID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string? Notes { get; set; }
        public int Status { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
    }
}
