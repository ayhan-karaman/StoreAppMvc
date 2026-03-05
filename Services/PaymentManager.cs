using AutoMapper;
using Azure.Core;
using Entities.Dtos;
using Entities.Models;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.Extensions.Configuration;
using Services.Contracts;

namespace Services
{
    public class PaymentManager : IPaymentService
    {
        private Iyzipay.Options _options;
        private IMapper _mapper;

        private readonly IOrderService _orderService;
        private readonly IAdressService _adressService;
        public PaymentManager(IConfiguration configuration, IMapper mapper, IAdressService adressService, IOrderService orderService)
        {
            var section = configuration.GetSection("PaymentOptions");
            _options = new()
            {
                ApiKey = section["ApiKey"],
                SecretKey = section["SecretKey"],
                BaseUrl = section["BaseUrl"]
            };
            _mapper = mapper;
            _adressService = adressService;
            _orderService = orderService;
        }

        public async Task<Payment> CheckoutAsync(CheckoutDto checkoutDto)
        {
            var order = new Order()
            {
                Name = checkoutDto.Address.ContactName,
                Adress = checkoutDto.Address.Description,
                Country = checkoutDto.Address.Country,
                City = checkoutDto.Address.City,
                Lines = checkoutDto.Lines,
                GiftWrap = false,
                Shipped = false,
                IsPayment = false,
            };
            _orderService.SaveOrder(order);

            var createPaymentRequest = MapCreatePaymentRequest(checkoutDto);
            createPaymentRequest.BasketId = $"BSKT0{order.Id}";
            createPaymentRequest.Buyer.Id = $"BYR0{order.Id}";
            createPaymentRequest.ConversationId = order.Id.ToString();
            var paymentResult = await PayAsync(createPaymentRequest);
            if (paymentResult.Status == "success")
            {
                order.IsPayment = true;
                _orderService.SaveOrder(order);
            }

            return paymentResult;

        }

        public async Task<string> CheckoutThreedsAsync(CheckoutDto checkoutDto)
        {
            var order = new Order()
            {
                Name = checkoutDto.Address.ContactName,
                Adress = checkoutDto.Address.Description,
                Country = checkoutDto.Address.Country,
                City = checkoutDto.Address.City,
                Lines = checkoutDto.Lines,
                GiftWrap = false,
                Shipped = false,
                IsPayment = false,
            };
            _orderService.SaveOrder(order);

            var createPaymentRequest = MapCreatePaymentRequest(checkoutDto);
            createPaymentRequest.BasketId = $"BSKT0{order.Id}";
            createPaymentRequest.Buyer.Id = $"BYR0{order.Id}";
            createPaymentRequest.ConversationId = order.Id.ToString();
            createPaymentRequest.CallbackUrl = checkoutDto.CallBackUrl;
            var htmlContent = await Pay3DSAsync(createPaymentRequest);
           

            return htmlContent;

        }

        private CreatePaymentRequest MapCreatePaymentRequest(CheckoutDto checkoutDto)
        {

            CreatePaymentRequest createPaymentRequest = new CreatePaymentRequest();
            createPaymentRequest.Locale = Locale.TR.ToString();
            createPaymentRequest.Price = checkoutDto.Lines.Sum(e => e.Product.Price * e.Quantity).ToString().Replace(",", ".");
            createPaymentRequest.PaidPrice = checkoutDto.Lines.Sum(e => e.Product.Price * e.Quantity).ToString().Replace(",", ".");
            createPaymentRequest.Currency = Currency.TRY.ToString();
            createPaymentRequest.Installment = 1;
            createPaymentRequest.GsmNumber = checkoutDto.Buyer.GsmNumber;
            createPaymentRequest.PaymentCard = _mapper.Map<PaymentCard>(checkoutDto.PaymentCard);
            createPaymentRequest.Buyer = _mapper.Map<Buyer>(checkoutDto.Buyer); ;
            createPaymentRequest.BillingAddress = _mapper.Map<Address>(checkoutDto.Address);
            createPaymentRequest.ShippingAddress = _mapper.Map<Address>(checkoutDto.Address);
            createPaymentRequest.PaymentChannel = PaymentChannel.WEB.ToString();
            createPaymentRequest.PaymentGroup = PaymentGroup.PRODUCT.ToString();
            createPaymentRequest.BasketItems = new List<BasketItem>();
            foreach (var item in checkoutDto.Lines)
            {
                for (int i = 0; i < item.Quantity; i++)
                {

                    createPaymentRequest.BasketItems.Add(
                         new BasketItem
                         {
                             Id = item.CartLineId.ToString(),
                             Name = item.Product.Name,
                             Category1 = item.Product.CategoryId.ToString(),
                             Category2 = item.Product.CategoryId.ToString(),
                             ItemType = BasketItemType.PHYSICAL.ToString(),
                             Price = item.Product.Price.ToString().Replace(",", ".")
                         }

                        );
                }
            }


            return createPaymentRequest;
        }

        private async Task<Payment> PayAsync(CreatePaymentRequest createPaymentRequest)
        {

            Payment payment = await Payment.Create(createPaymentRequest, _options);
            return payment;
        }

        private async Task<string> Pay3DSAsync(CreatePaymentRequest createPaymentRequest)
        {
            ThreedsInitialize threedsInitialize = await ThreedsInitialize.Create(createPaymentRequest, _options);
            return threedsInitialize.HtmlContent;
        }

     
    }
}
