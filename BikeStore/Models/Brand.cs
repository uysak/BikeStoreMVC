using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CoreMVC.Model;

namespace BikeStore.Models
{
    public class Brand : IModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BrandId { get; set; }

        public string BrandName { get; set; }
    }
}
