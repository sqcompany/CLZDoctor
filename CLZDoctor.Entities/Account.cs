
namespace CLZDoctor.Entities
{
    public class Account : BaseEntity
    {
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public int CurrState { get; set; }
    }
}
