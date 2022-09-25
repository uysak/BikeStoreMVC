using BikeStore.Data;
using BikeStore.Models;
using BikeStore.Models.DTOs;
using BikeStore.Repository.Abstract;
using Core.DataAccess.EntityFramework;

namespace BikeStore.Repository.Concrete
{
    public class CategoryRepository : EfEntityRepositoryBase<Category, BikeStoresDbContext>, ICategoryRepository
    {
        public List<CategoryDetailDto> GetCategories()
        {
            using (var dbContext = new BikeStoresDbContext())
            {
                var categories = (from cg in dbContext.Categories
                    join img in dbContext.Images
                        on cg.CategoryId equals img.CategoryId
                    select new CategoryDetailDto
                    {
                        CategoryId = cg.CategoryId,
                        CategoryName = cg.CategoryName,
                        CategoryDetail = cg.CategoryDetail,
                        Images = img
                    }).ToList();

                return categories;
            }
            
        }
    }
}
