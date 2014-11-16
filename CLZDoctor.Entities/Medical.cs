

namespace CLZDoctor.Entities
{
    public class Medical : BaseEntity
    {
        public string Patient { get; set; }
        public int Age { get; set; }
        public int Gender { get; set; }
        public string Diagnose { get; set; }
        public string Treatment { get; set; }
        public string Contract { get; set; }
        public int IsVisit { get; set; }
        public string VisitResult { get; set; }
        public string Prescription { get; set; }
    }
}
