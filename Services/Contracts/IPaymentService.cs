
using Entities.Dtos;
using Iyzipay.Model;

namespace Services.Contracts
{
    public interface IPaymentService
    {
        Task<Payment> CheckoutAsync(CheckoutDto checkoutDto);
        Task<string> CheckoutThreedsAsync(CheckoutDto checkoutDto);
    }
}
