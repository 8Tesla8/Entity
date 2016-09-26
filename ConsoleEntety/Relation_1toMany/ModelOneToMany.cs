using Relation_1toMany.DataBase;

namespace Relation_1toMany
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ModelOneToMany : DbContext
    {
        public ModelOneToMany()
            : base("name=ModelOneToMany")
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
    }
}