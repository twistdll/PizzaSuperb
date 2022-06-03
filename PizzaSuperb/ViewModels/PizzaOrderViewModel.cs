namespace PizzaSuperb.ViewModels
{
    public class PizzaOrderViewModel
    {
        public string? PhotoUrl { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public double TotalPrice { get; set; }
    }
}
