using Employment.Core.Enums;

namespace Employment.Core.DTOs
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Employer Employer { get; set; }
        public Decimal PayRate { get; set; }
        public PayPeriod PayPeriod { get; set; }
        public PayType PayType { get; set; }
    }
}
