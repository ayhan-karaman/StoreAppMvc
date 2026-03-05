
using Entities.Models.Payments;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class AddressManager : IAdressService
    {
        private readonly IRepositoryManager _repositoryManager;

        public AddressManager(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public Address CreateAddress(Address address)
        {
            _repositoryManager.AddressRepository.Create(address);
            _repositoryManager.SaveChanges();
            return address;
        }
    }
}
