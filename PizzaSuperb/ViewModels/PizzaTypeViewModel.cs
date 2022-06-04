namespace PizzaSuperb.ViewModels
{
    public class PizzaTypeViewModel
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public string? PhotoUrl { get; init; }
        public double OldPrice { get; init; }
        public double Price { get; init; }
        public int Count { get; init; }
    }
}
