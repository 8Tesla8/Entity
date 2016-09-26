using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relation_ManyToMany.Tables
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        //один продукт может быть в нескольких заказах
        //внешний ключ при такой связи не нужен он создается автоматически
        public ICollection<Order> Order { get; set; }

        public Product()
        {
            Order = new List<Order>();
        }
    }
}
