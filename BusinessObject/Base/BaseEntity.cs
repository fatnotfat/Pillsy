using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Base
{
    public class BaseEntity
    {
        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; } 
    }
}
