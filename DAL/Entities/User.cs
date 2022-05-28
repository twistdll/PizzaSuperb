using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public int Telephone { get; set; }
        public DateTime DateCreated { get; set; }

        public List<Order> Orders { get; set; }
    }
}
