using System;

namespace CLZDoctor.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            State = 0;
            CreateTime = DateTime.Now;
            UpdateTime = DateTime.Now;
        }
        public int Id { get; set; }
        public int? State { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
