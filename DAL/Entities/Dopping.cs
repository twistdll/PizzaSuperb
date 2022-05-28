using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Dopping
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public int Price { get; set; }

        public List<OrderConfiguration> OrderConfigurations { get; set; }
    }
}
