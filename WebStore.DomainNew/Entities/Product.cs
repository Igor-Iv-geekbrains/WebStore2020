﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebStore.Domain.Entities.Base;
using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.Domain.Entities
{
    [Table("Products")]
    public class Product : NamedEntity, IOrderEntity
    {
        public int Order { get; set; }
        public int CategoryId { get; set; }
        public int? BrandId { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string Manufacturer { get; set; }
        public decimal Sales { get; set; }
        

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [ForeignKey("BrandId")]
        public virtual Brand Brand { get; set; }

    }
}