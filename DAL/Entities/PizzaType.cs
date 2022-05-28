using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class PizzaType
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public int Price { get; set; }
        public int? Discount { get; set; }
        public bool IsForSale { get; set; }

        public List<OrderConfiguration> OrderConfigurations { get; set; }
    }
}
