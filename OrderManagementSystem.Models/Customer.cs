namespace OrderManagementSystem.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public CustomerSegment Segment { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }


    public enum CustomerSegment
    {
        Regular = 0,
        Silver = 2,
        Gold = 3,
        Platinum = 4,
    }
}
