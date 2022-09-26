using Employment.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employment.Data.Models
{
    public class Shift
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public virtual Employer Employer { get; set; }

        [Required]
        public virtual Role Role { get; set; }

        [Required]
        public string RoleName { get; set; }

        [Required]
        public Decimal PayRate { get; set; }

        [Required]
        public PayPeriod PayPeriod { get; set; }

        [Required]
        public PayType PayType { get; set; }

        [Required]
        public DateTime StartDateTime { get; set; }

        [Required]
        public DateTime EndDateTime { get; set; }

        [Required]
        public int BreakInMinutes { get; set; }

        [Required]
        public DateTime RecordedStartDateTime { get; set; }

        [Required]
        public DateTime RecordedEndDateTime { get; set; }

        [Required]
        public int RecordedBreakInMinutes { get; set; }

        [Required]
        public bool IsProspective { get; set; }

        public Core.DTOs.Shift ToDto()
        {
            return new Core.DTOs.Shift
            {
                Id = Id,
                Employer = Employer.ToDto(),
                Role = Role.ToDto(),
                StartDateTime = StartDateTime,
                EndDateTime = EndDateTime,
                BreakInMinutes = BreakInMinutes,
                RecordedStartDateTime = RecordedStartDateTime,
                RecordedEndDateTime = RecordedEndDateTime,
                RecordedBreakInMinutes = RecordedBreakInMinutes,
                IsProspective = IsProspective
            };
        }
    }
}
