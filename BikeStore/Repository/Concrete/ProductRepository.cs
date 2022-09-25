﻿using BikeStore.Data;
using BikeStore.Models;
using BikeStore.Models.DTOs;
using BikeStore.Repository.Abstract;
using Core.DataAccess.EntityFramework;

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
                    join img in dbContext.Images on pd.ProductId equals img.ProductId

                    select new ProductDetailDto
                    {
                        ListPrice = pd.ListPrice,
                        ModelYear = pd.ModelYear,
                        ProductId = pd.ProductId,
                        ProductName = pd.ProductName,
                        BrandName = bd.BrandName,
                        CategoryName = cg.CategoryName
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

    }
}
