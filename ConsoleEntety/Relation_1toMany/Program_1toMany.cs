using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Relation_1toMany.DataBase;

namespace Relation_1toMany
{
    class Program_1toMany
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<ModelOneToMany>());

            using (ModelOneToMany oneToMany = new ModelOneToMany())
            {
                //Products
                Product p1 = new Product { Name = "Nokia 890", Price = 500 };
                Product p2 = new Product { Name = "Nokia 580", Price = 700 };
                Product p3 = new Product { Name = "Samsung S4", Price = 650 };
                Product p4 = new Product { Name = "Sony Ericson E3", Price = 990 };

                oneToMany.Products.AddRange(new List<Product> { p1, p2, p3, p4});
                oneToMany.SaveChanges();

                var products = oneToMany.Products.ToList();

                foreach (var item in products)
                {
                    Console.WriteLine("{0}.{1} - {2} ({3})",
                        item.Id, item.Name, item.Price,
                        item.OrderId != null ? item.Order.Customer: "No customer");
                }

                Console.WriteLine("-Выборка с нескольких таблиц", 20);
                //Console.ReadKey();

                //Orders
                Order r1 = new Order { Customer = "Max", Quantity = 2, Product = new List<Product> {p1, p2 } };
                Order r2 = new Order { Customer = "Yuri", Quantity = 3, Product = new List<Product> { p3, p4 } };

                oneToMany.Orders.AddRange(new List<Order> {r1, r2});
                oneToMany.SaveChanges();

                var products1 = oneToMany.Products.ToList();

                foreach (var item in products1)
                {
                    Console.WriteLine("{0}.{1} - {2} ({3})",
                        item.Id, item.Name, item.Price,
                        item.OrderId != null ? item.Order.Customer : "No customer");
                }

                Console.WriteLine("-",20);
                //Console.ReadKey();


                var orders = oneToMany.Orders.ToList();

                foreach (var itemOrder in orders)
                {
                    Console.WriteLine("{0}.{1}", itemOrder.Id, itemOrder.Customer);

                    if(itemOrder.Product == null) continue;

                    foreach (var itemProduct in itemOrder.Product)
                    {
                        Console.WriteLine("{0} - {1} * {2} = {3}",
                            itemProduct.Name, itemProduct.Price, itemOrder.Quantity, itemProduct.Price * itemOrder.Quantity);
                    }
                    Console.WriteLine("-", 20);
                }
                Console.ReadKey();
            }
        }
    }
}
