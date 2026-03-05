using Entities.Models.Payments;


namespace Entities.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Adress { get; set; }
        public bool IsPayment { get; set; } 
        public bool GiftWrap { get; set; } 
        public bool Shipped { get; set; }

        
        public IEnumerable<CartLine>? Lines { get; set; } = new List<CartLine>();
        public DateTime OrderedAt { get; set; } = DateTime.UtcNow;
    }
}