using System.ComponentModel.DataAnnotations;

namespace h_data.Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public int TotalQuantity { get; set; }
        [Required]
        public decimal ListPrice { get; set; }
        [Required]
        public decimal Freight { get; set; }
        [Required]
        public decimal Discount { get; set; }
        [Required]
        public decimal NetPrice { get; set; }
    }
}
