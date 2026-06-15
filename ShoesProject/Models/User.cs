using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ShoesProject
{
    public partial class User
    {
        public User()
        {
            Order = new HashSet<Order>();
        }

        public int Id { get; set; }
        public int IdRole { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Login { get; set; }
        public string Pass { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Order> Order { get; set; }
        public string FullName => $"{LastName} {FirstName} {MiddleName}";
    }
}
