using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Dopping
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public double Price { get; set; }
        public string? PhotoUrl { get; set; }

        public List<OrderConfiguration> OrderConfigurations { get; set; }
    }
}
