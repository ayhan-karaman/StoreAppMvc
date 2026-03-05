using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IOrderService _orderService;
        private readonly IAuthService _authService;
        private readonly IAdressService _adressService;
        private readonly IPaymentService _paymentService;

        public ServiceManager(IProductService productService, ICategoryService categoryService, IOrderService orderService, IAuthService authService, IAdressService adressService, IPaymentService paymentService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _orderService = orderService;
            _authService = authService;
            _adressService = adressService;
            _paymentService = paymentService;
        }

        public IProductService ProductService => _productService;

        public ICategoryService CategoryService => _categoryService;

        public IOrderService OrderService => _orderService;

        public IAuthService AuthService => _authService;

        public IAdressService AdressService => _adressService;

        public IPaymentService PaymentService => _paymentService;
    }
}