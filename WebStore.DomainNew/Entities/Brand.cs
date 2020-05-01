using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebStore.Domain.Entities.Base;
using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.Domain.Entities
{
    [Table("ProductBrands")]
    public class Brand : NamedEntity, IOrderEntity
    {
        public int Order { get ; set ; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
