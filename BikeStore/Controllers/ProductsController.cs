using BikeStore.Models;
using BikeStore.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BikeStore.Controllers
{
    public class ProductsController : Controller
    {
        private IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult GetProducts(int id)
        {
           var products = _productRepository.GetProducts(id);
           return View(products);
        }

        public IActionResult ProductDetail(int id)
        {
            var productDetail = _productRepository.GetProduct(id);
            return View(productDetail);
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]  
        public IActionResult AddProduct(Product product)
        {
            _productRepository.Add(product);
            return View();
        }
    }
}
