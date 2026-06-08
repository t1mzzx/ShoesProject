using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ShoesProject
{
    public partial class Orders
    {
        public Orders()
        {
            ProductsOrders = new HashSet<ProductsOrders>();
        }

        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int IdDeliveryPoint { get; set; }
        public int IdUser { get; set; }
        public int Code { get; set; }
        public int IdStatuses { get; set; }

        public virtual DeliveryPoints IdDeliveryPointNavigation { get; set; }
        public virtual Statuses IdStatusesNavigation { get; set; }
        public virtual Users IdUserNavigation { get; set; }
        public virtual ICollection<ProductsOrders> ProductsOrders { get; set; }
    }
}
