using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Household.Models
{
    public class Products
    {
        public int Id { get; set; }

        [Display(Name = "Product Type")]
        public int ProductTypeId { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string SerialNumber { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime WarrantyExperation { get; set; }

        [Required]
        public string UserId { get; set; }

        public int RoomId { get; set; }

        public ProductType ProductType { get; set; }

        public Room Room { get; set; }
        




    }
}
