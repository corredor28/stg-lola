using System.ComponentModel.DataAnnotations;

namespace h_data.DTOs
{
    public class OrderAnimal
    {
        [Required]
        public int AnimalId { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
