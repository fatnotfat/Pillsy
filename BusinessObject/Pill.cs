using BusinessObject.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Pill : BaseEntity
    {
        public Guid PillId { get; set; }
        public string PillName { get; set; }
        public string PillDescription { get; set; }
        public int Frequency { get; set; }
        public string Period { get; set; }
        public string Unit { get; set; }
        public int Status { get; set; }
        public Guid PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }
        public Guid ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
        public int Index { get; set; }
    }
}
