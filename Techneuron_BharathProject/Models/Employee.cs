using System.ComponentModel.DataAnnotations;

namespace Techneuron_BharathProject.Models
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]

        public string Name { get; set; }
        [Required]
        [StringLength(100)]

        public string Description { get; set; }
    }
}
