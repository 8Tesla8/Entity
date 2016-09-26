using Relation_1to1.DataBase;

namespace Relation_1to1
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Model1to1 : DbContext
    {
        public Model1to1()
            : base("name=Model1to1")
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
    }
}