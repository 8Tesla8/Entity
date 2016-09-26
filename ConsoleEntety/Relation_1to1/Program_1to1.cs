using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Relation_1to1.DataBase;

namespace Relation_1to1
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<Model1to1>());

            using (Model1to1 db = new Model1to1())
            {
                /*
                Product pr1 = new Product
                {
                    Name = "Coca Cola",
                    Price = 20
                };
                Product pr2 = new Product
                {
                    Name = "Pepsi",
                    Price = 25
                };

                //Добавления записей
                //db.Products.Add(pr1);
                //db.Products.Add(pr2);

                //или
                db.Products.AddRange(new List<Product> {pr1, pr2});

                //Сохраняем изменения в базе
                db.SaveChanges();

                //Создание заказа
                Order order1 = new Order
                {
                    Customer = "Alex",
                    Quantity = 3,
                    Product = pr2 // может быть nullable 
                };
                Order order2 = new Order
                {
                    Customer = "Max",
                    Quantity = 2,
                    Product = pr1
                };

                db.Orders.AddRange(new List<Order> {order1, order2});

                db.SaveChanges();
                */

                //вывод из базы данных, выборка
                var orders = db.Orders.ToList();

                foreach (var item in orders)
                {
                    Console.WriteLine(
                        "{0}.{1} -> ({2}) price: {3}$ - {4} quantity", 
                        item.Id, 
                        item.Customer,
                        item.Product != null ? item.Product.Name : "X",
                        item.Product != null ? Convert.ToString(item.Product.Price) : "X",
                        item.Quantity);    
                }

                Console.ReadKey();

            }
        }
    }
}
