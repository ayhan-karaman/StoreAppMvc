

namespace Entities.Models.Payments
{
    public class PaymentCard
    {

        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string ExpireMonth { get; set; }
        public string ExpireYear { get; set; }
        public string Cvc { get; set; }
        public int RegisterCard { get; set; }

    }
}
