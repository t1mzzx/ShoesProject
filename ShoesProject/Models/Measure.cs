using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ShoesProject
{
    public partial class Measure
    {
        public Measure()
        {
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string MeasureName { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
