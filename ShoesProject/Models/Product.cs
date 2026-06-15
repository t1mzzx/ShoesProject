using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ShoesProject
{
    public partial class Product
    {
        public Product()
        {
            ProductsOrder = new HashSet<ProductsOrder>();
        }

        public int Id { get; set; }
        public string Art { get; set; }
        public int IdType { get; set; }
        public int IdMeasure { get; set; }
        public decimal Price { get; set; }
        public int IdSupplier { get; set; }
        public int IdManufacturer { get; set; }
        public int IdCategory { get; set; }
        public int Discount { get; set; }
        public int CointInStock { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }

        public virtual Categorie IdCategoryNavigation { get; set; }
        public virtual Manufacturer IdManufacturerNavigation { get; set; }
        public virtual Measure IdMeasureNavigation { get; set; }
        public virtual Supplier IdSupplierNavigation { get; set; }
        public virtual ProductType IdTypeNavigation { get; set; }
        public virtual ICollection<ProductsOrder> ProductsOrder { get; set; }
    }
}
