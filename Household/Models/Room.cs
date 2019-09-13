using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Household.Models
{
    public class Room
    {
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser user { get; set; }
        public string Name { get; set; }

        public string ImagePath { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
