using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace RandomActs.Models
{
    public class RAOKContext : DbContext
    {
        public RAOKContext()
            : base("RandomActsDB")
        {
        }
        
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<RandomActs.Models.RAOKContext>());

        public DbSet<RandomActs.Models.RandomAct> RandomActs { get; set; }

        public DbSet<RandomActs.Models.RandomActor> RandomActors { get; set; }

        public DbSet<RandomActs.Models.RandomActActor> RandomActActors { get; set; }
    }
}
