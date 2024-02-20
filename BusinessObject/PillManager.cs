using BusinessObject.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class PillManager : BaseEntity
    {
        public Guid PillManagerId { get; set; }
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }
        public List<Pill> Pill { get; set; }
        public int Status { get; set;}
        public DateTime TakenTime { get; set; }
    }
}
