using BikeStore.Models;
using Core.DataAccess;

namespace BikeStore.Repository.Abstract
{
    public interface ICustomerRepository : IEntityRepository<Customer>
    {
    }
}
