
using System.Collections.Generic;

namespace CLZDoctor.Entities
{
    public class PrescripType : BaseEntity
    {
        public string Name { get; set; }
        public int ParentId { get; set; }
        public string Remark { get; set; }
        public List<PrescripType> children { get; set; } 
    }
}
