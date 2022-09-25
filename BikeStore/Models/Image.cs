using CoreMVC.Model;

namespace BikeStore.Models
{
	public class Image : IModel
	{
        public int ImageId { get; set; }
        public int? ProductId { get; set; }
        public int? CategoryId { get; set; }
        public string ImageURL { get; set; }
	}
}
