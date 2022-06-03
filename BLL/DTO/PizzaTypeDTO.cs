namespace BLL.DTO
{
    public record PizzaTypeDTO
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public string? PhotoUrl { get; init; }
        public double OldPrice { get; init; }
        public double Price { get; init; } 
    }
}
