using BikeStore.Data;
using BikeStore.Models;
using BikeStore.Models.DTOs;
using BikeStore.Repository.Abstract;
using Core.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace BikeStore.Repository.Concrete
{
    public class ProductRepository : EfEntityRepositoryBase<Product, BikeStoresDbContext>, IProductRepository
    {
        private IImageRepository _imageRepository;
        public ProductRepository(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }
        public List<ProductDetailDto> GetProducts(int categoryId)
        {
            using (var dbContext = new BikeStoresDbContext())
            {
                var products = (from pd in dbContext.Products.Where(pd=> pd.CategoryId == categoryId)
                    join bd in dbContext.Brands on pd.BrandId equals bd.BrandId
                    join cg in dbContext.Categories on pd.CategoryId equals cg.CategoryId

                    

                    select new ProductDetailDto
                    {
                        ListPrice = pd.ListPrice,
                        ModelYear = pd.ModelYear,
                        ProductId = pd.ProductId,
                        ProductName = pd.ProductName,
                        BrandName = bd.BrandName,
                        CategoryName = cg.CategoryName,
                        CategoryId = cg.CategoryId
                    }).ToList();

                foreach (var product in products)
                {
                    var images = _imageRepository.GetAll(img => img.ProductId == product.ProductId);
                    product.Images = new List<Image>();
                    foreach (var img in images)
                    {
                        product.Images.Add(img);
                    }
                }

                return products;
            }
        }

        public List<ProductDetailDto> GetProduct(int productId)
        {
            using (var dbContext = new BikeStoresDbContext())
            {
                var product = (from pd in dbContext.Products.Where(pd=> pd.ProductId == productId)
                    join bd in dbContext.Brands on pd.BrandId equals bd.BrandId
                    join cg in dbContext.Categories on pd.CategoryId equals cg.CategoryId
                    join img in dbContext.Images on pd.ProductId equals img.ProductId

                    select new ProductDetailDto
                    {
                        ListPrice = pd.ListPrice,
                        ModelYear = pd.ModelYear,
                        ProductId = pd.ProductId,
                        ProductName = pd.ProductName,
                        BrandName = bd.BrandName,
                        CategoryName = cg.CategoryName,
                        CategoryId = cg.CategoryId
                    }).ToList();

                var images = dbContext.Images.Where(img => img.ProductId == productId).ToList();
                product[0].Images = new List<Image>();

                product[0].Images.Add(images[0]);
                return product;
            }
        }

    }
}
