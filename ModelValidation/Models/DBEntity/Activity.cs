using System.ComponentModel.DataAnnotations;

namespace ModelValidation.Models.DBEntity
{
    public class Activity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Name { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string BusinessHours { get; set; } = null!;
    }
}
