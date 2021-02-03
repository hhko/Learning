using System;
using System.Collections.Generic;
using System.Text;

namespace Ch2.CreatingFixture
{
    public class Order
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public DateTime OrderDate { get; set; }

        public Order(Customer customer)
        {
            Customer = customer;
        }
    }
}
