﻿using E_Commerce.Domain.Entities.Common;

namespace E_Commerce.Domain.Entities
{
    public class Order : BaseEntity
    {
        public string Description { get; set; }
        public string Address { get; set; }

        public ICollection<Product> Products { get; set; }

        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
