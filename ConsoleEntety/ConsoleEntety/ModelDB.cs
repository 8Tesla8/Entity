namespace ConsoleEntety
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ModelDB : DbContext
    {
        // Your context has been configured to use a 'ModelDB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ConsoleEntety.ModelDB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ModelDB' 
        // connection string in the application configuration file.
        public ModelDB()
            : base("name=ModelDB")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

         public virtual DbSet<PersonalInfo> PersonalInfos { get; set; }
    }

}