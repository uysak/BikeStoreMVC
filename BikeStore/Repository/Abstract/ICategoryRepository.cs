using BikeStore.Models;
using BikeStore.Models.DTOs;
using Core.DataAccess;

namespace BikeStore.Repository.Abstract
{
    public interface ICategoryRepository : IEntityRepository<Category>
    {
        public List<CategoryDetailDto> GetCategories();
    }


}
