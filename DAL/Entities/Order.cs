using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime DateCreated { get; set; }
        public int TotalPrice { get; set; }
        public string? Address { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public List<OrderConfiguration> OrderConfigurations { get; set; }
    }
}
