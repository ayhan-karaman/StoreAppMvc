
using Entities.Models.Payments;
using Repositories.Contracts;

namespace Repositories
{
    public class AddressRepository : RepositoryBase<Address>, IAddressRepository
    {
        public AddressRepository(RepositoryContext context) : base(context)
        {
        }
    }
}
