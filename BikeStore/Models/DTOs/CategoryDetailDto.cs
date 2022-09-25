using CoreMVC.Model;

namespace BikeStore.Models.DTOs
{
    public class CategoryDetailDto : IDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDetail { get; set; }
        public Image Images { get; set; }
    }
}
