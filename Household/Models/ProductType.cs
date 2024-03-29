﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Household.Models
{
    public class ProductType
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Products> Products { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
