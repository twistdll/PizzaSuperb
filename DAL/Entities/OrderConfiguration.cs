using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class OrderConfiguration
    {
        [Key]
        public int Id { get; set; }
        public Guid OrderId { get; set; }
        public int PizzaTypeId { get; set; }
        public int DoppingId { get; set; }

        public Order Order { get; set; }
        public PizzaType PizzaType { get; set; }
        public Dopping Dopping { get; set; }
    }
}
