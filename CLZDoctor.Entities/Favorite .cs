
namespace CLZDoctor.Entities
{
    public class Favorite : BaseEntity
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int PrescripId { get; set; }
        public string PrescripName { get; set; }
        public string Remark { get; set; }
    }
}
