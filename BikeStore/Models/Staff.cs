using System.ComponentModel.DataAnnotations;
using CoreMVC.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikeStore.Models
{
    public class Staff : IModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StaffId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string? Phone { get; set; }

        public string Email { get; set; }

        public byte Active { get; set; }
        public int StoreId { get; set; }
        public int? ManagerId { get; set; }


    }
}
