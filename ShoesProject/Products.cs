using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ShoesProject
{
    public partial class Products
    {
        public Products()
        {
            ProductsOrders = new HashSet<ProductsOrders>();
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

        public virtual Categories IdCategoryNavigation { get; set; }
        public virtual Manufacturers IdManufacturerNavigation { get; set; }
        public virtual Measures IdMeasureNavigation { get; set; }
        public virtual Suppliers IdSupplierNavigation { get; set; }
        public virtual ProductTypes IdTypeNavigation { get; set; }
        public virtual ICollection<ProductsOrders> ProductsOrders { get; set; }
    }
}
