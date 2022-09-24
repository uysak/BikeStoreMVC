using BikeStore.Data;
using BikeStore.Models;
using BikeStore.Repository.Abstract;
using Core.DataAccess.EntityFramework;

namespace BikeStore.Repository.Concrete
{
    public class StaffRepository : EfEntityRepositoryBase<Staff, BikeStoresDbContext>, IStaffRepository
    {

    }
}

