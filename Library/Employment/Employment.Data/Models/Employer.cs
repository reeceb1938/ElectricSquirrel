using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Employment.Data.Models
{
    public class Employer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public IEnumerable<Role>? Roles { get; set; }

        public IEnumerable<Shift>? Shifts { get; set; }

        public Core.DTOs.Employer ToDto()
        {
            return new Core.DTOs.Employer
            {
                Id = Id,
                Name = Name
            };
        }
    }
}
