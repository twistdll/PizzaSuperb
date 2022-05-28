using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Promocode
    {
        [Key]
        public string Text { get; set; }
        public int Discount { get; set; }
    }
}
