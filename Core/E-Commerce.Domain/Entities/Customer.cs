using E_Commerce.Domain.Entities.Common;

namespace E_Commerce.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public ICollection<Order> Orders { get; set; }
    }
}
