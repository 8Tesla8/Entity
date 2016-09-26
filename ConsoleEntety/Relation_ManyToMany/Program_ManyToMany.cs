using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Relation_ManyToMany.Tables;

namespace Relation_ManyToMany
{
    class Program_ManyToMany
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<ModelManyToMany>());

            using (ModelManyToMany db = new ModelManyToMany())
            {
                //Products
                Product p1 = new Product { Name = "Nokia 890", Price = 500 };
                Product p2 = new Product { Name = "Nokia 580", Price = 700 };
                Product p3 = new Product { Name = "Samsung S4", Price = 650 };
                Product p4 = new Product { Name = "Sony Ericson E3", Price = 990 };

                db.Products.AddRange(new List<Product> { p1, p2, p3, p4 });
                db.SaveChanges();

                //Order
                Order r1 = new Order { Customer = "Max", Quantity = 2 };
                r1.Product.Add(p1);
                r1.Product.Add(p3);
                r1.Product.Add(p4);


                Order r2 = new Order { Customer = "Yuri", Quantity = 3 };
                r2.Product.Add(p1);
                r2.Product.Add(p2);
                r2.Product.Add(p3);

                db.Orders.AddRange(new List<Order> {r1, r2});
                db.SaveChanges();

                //Include подключает еще одну таблицу
                foreach (var itemProd in db.Products.Include(p=>p.Order))
                {
                    Console.WriteLine("{0}.{1}", itemProd.Id, itemProd.Name);

                    if(itemProd.Order == null) continue;

                    foreach (var itemOrder in itemProd.Order)
                    {
                        Console.WriteLine("{0}.{1}", itemOrder.Id, itemOrder.Customer);
                    }
                    Console.WriteLine("---------");
                }
                Console.WriteLine("=========");


                foreach (var itemOrder in db.Orders.Include(p => p.Product))
                {
                    
                    Console.WriteLine("{0}.{1}", itemOrder.Id, itemOrder.Customer);

                    if (itemOrder.Product == null) continue;

                    foreach (var itemProd in itemOrder.Product)
                    {
                        Console.WriteLine("{0}.{1} - {2}", itemProd.Id, itemProd.Name, itemProd.Price);
                    }
                    Console.WriteLine("---------");
                }
                Console.WriteLine("=========");

                Console.ReadKey();
            }
        }
    }
}
