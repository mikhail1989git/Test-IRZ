using Domain.Entity;
using System;
using System.Data.Entity;
using System.Linq;

namespace Context
{
    public class DataDbContext : DbContext
    {
        public DbSet<RequestInfo> Info { get; set; }

        public DataDbContext() : base("DbConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}