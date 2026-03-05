using Entities.Models;
using Entities.Models.Payments;

namespace StoreApp.Models
{
    public class CheckoutModel
    {
        public Order Order { get; set; } = new Order();
        public Address Adress { get; set; }
        public Buyer Buyer { get; set; }
        public PaymentCard PaymentCard { get; set; }
        public string? ReturnUrl { get; set; } = "/";
    }
}
