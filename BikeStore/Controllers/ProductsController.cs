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
    }
}
