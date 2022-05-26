﻿using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    internal class PizzaType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int? Discount { get; set; }
    }
}
