using Relation_ManyToMany.Tables;

namespace Relation_ManyToMany
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ModelManyToMany : DbContext
    {

        public ModelManyToMany()
            : base("name=ModelManyToMany")
        {
        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
    }
}