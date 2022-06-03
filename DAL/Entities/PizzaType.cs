using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class PizzaType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        [Range(0, 0.99)]
        public double? Discount { get; set; }
        public bool IsForSale { get; set; }
        public string? PhotoUrl { get; set; }

        public List<OrderConfiguration> OrderConfigurations { get; set; }
    }
}
