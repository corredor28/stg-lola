using System.ComponentModel.DataAnnotations;

namespace h_data.Entities
{
    public class Animal
    {
        [Key]
        public int AnimalId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Breed { get; set; }
        [Required]
        public DateTime? BirthDate { get; set; }
        [Required]
        public string? Sex { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string? Status { get; set; }
    }
}
