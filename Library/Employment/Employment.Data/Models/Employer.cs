using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    }
}
