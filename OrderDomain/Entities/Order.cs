using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDomain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public Costumer costumer { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal total { get; set; }

        public List<OrderItem> Item { get; set; }

        public void AddItem(OrderItem item)
        {
            Item.Add(item);
            total += item.Product.Price * item.Quantity;
        }
        public virtual void RemoveItem(OrderItem item)
        {
            Item.Remove(item);
            total -= item.Product.Price * item.Quantity;
        }
    }
}
