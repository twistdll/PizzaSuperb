namespace BLL.DTO
{
    public record OrderDTO
    {
        public DateTime DateCreated { get; set; }
        public double TotalPrice { get; set; }
        public string? Address { get; set; }
        public UserDTO User { get; set; }
    }
}
