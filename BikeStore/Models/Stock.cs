using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CoreMVC.Model;

namespace BikeStore.Models
{
    public class Stock : IModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public int? Quantity { get; set; }
    }
}
