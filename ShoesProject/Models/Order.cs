using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ShoesProject
{
    public partial class Order
    {
        public Order()
        {
            ProductsOrder = new HashSet<ProductsOrder>();
        }

        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int IdDeliveryPoint { get; set; }
        public int IdUser { get; set; }
        public int Code { get; set; }
        public int IdStatuses { get; set; }

        public virtual DeliveryPoint IdDeliveryPointNavigation { get; set; }
        public virtual Statuse IdStatusesNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
        public virtual ICollection<ProductsOrder> ProductsOrder { get; set; }
    }
}
