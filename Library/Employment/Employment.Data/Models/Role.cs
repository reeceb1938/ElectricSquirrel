using Employment.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employment.Data.Models
{
    public class Role
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public virtual Employer Employer { get; set; }

        [Required]
        public Decimal PayRate { get; set; }

        [Required]
        public PayPeriod PayPeriod { get; set; }

        [Required]
        public PayType PayType { get; set; }

        public IEnumerable<Shift>? Shifts { get; set; }

        public Core.DTOs.Role ToDto()
        {
            return new Core.DTOs.Role
            {
                Id = Id,
                Name = Name,
                Employer = Employer.ToDto(),
                PayRate = PayRate,
                PayPeriod = PayPeriod,
                PayType = PayType
            };
        }
    }
}
