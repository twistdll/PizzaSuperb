using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class OrderConfiguration
    {
        [Key]
        public int Id { get; set; }
        public Guid OrderId { get; set; }

        public int ProductId { get; set; }
        public int ProductCount { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
