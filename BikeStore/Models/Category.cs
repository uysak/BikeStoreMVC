using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CoreMVC.Model;

namespace BikeStore.Models
{
    public class Category : IModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
        public string CategoryImageURL { get; set; }
        public string CategoryDetail { get; set; }
    }
}
