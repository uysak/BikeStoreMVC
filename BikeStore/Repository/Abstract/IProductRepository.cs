using BikeStore.Models;
using BikeStore.Models.DTOs;
using Core.DataAccess;

namespace BikeStore.Repository.Abstract
{
    public interface IProductRepository : IEntityRepository<Product>
    {
        public List<ProductDetailDto> GetProducts(int categoryId);
    }
}