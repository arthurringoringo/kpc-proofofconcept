using System;
using apitest.Entities;
using Microsoft.EntityFrameworkCore;

namespace apitest.Database
{
    public class ApiDbContext : DbContext 
    {
        public ApiDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<StoreA> StoreA { get; set; }
        public DbSet<StoreB> StoreB { get; set; }

        internal object Find(string id)
        {
            throw new NotImplementedException();
        }
    }
}
