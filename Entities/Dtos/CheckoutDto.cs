

using Entities.Models;
using Entities.Models.Payments;

namespace Entities.Dtos
{
    public class CheckoutDto
    {
        
        public PaymentCard PaymentCard { get; set; } = new PaymentCard();
        public Buyer Buyer { get; set; } = new Buyer();
        public Address Address { get; set; } = new Address();
        public bool Is3DSPay { get; set; } = false;
        public string? CallBackUrl { get; set; }
        public IEnumerable<CartLine>? Lines { get; set; } = new List<CartLine>();
    }
}
