using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relation_ManyToMany.Tables
{
    public class Order //в одном заказе может быть несколько продуктов
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public int Quantity { get; set; }

        //где колекция это связь кo многим, где сылка это связь один к одному
        public ICollection<Product> Product { get; set; }

        public Order()
        {
            Product = new List<Product>();
        }
    }
}
