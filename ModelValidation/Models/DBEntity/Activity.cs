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
        public DateTime StartAt { get; set; }

        [Required]
        public DateTime EndAt { get; set; }

        [Required]
        [StringLength(100)]
        public string BusinessHours { get; set; } = null!;
    }
}
