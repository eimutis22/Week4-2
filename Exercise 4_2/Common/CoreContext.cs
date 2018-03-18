namespace CoreAPI
{
    using Common.Model;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class CoreContext : DbContext
    {
        public CoreContext() : base("CoreContextDB")
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}