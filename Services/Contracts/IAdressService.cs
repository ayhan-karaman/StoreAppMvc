

using Entities.Models.Payments;

namespace Services.Contracts
{
    public interface IAdressService
    {
        Address CreateAddress(Address address);
    }
}
