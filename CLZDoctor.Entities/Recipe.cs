
namespace CLZDoctor.Entities
{
    public class Recipe : BaseEntity
    {
        public int PrescripId { get; set; }
        public int MaterialsId { get; set; }
        public string Name { get; set; }
        public int Dosage { get; set; }
        public string Unit { get; set; }
    }
}
