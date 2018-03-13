using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CST356_Week_4_Lab.Data.Entities;

namespace CST356_Week_4_Lab.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MyDbInitializer());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Pet> Pets { get; set; }
    }

    public class MyDbInitializer : DropCreateDatabaseIfModelChanges<MyDbContext>
    {
        // intentionally left blank
    }
}