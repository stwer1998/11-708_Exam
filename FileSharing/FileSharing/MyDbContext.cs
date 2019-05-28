using FileSharing.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileSharing
{
    public class MyDbContext: DbContext
    {
        public DbSet<AplicationFile> aplicationFiles { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        const string connectionString = "localdb)\\mssqllocaldb;Database=EFProviders.InMemory;Trusted_Connection=True;MultipleActiveResultSets=true";
        public MyDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(connectionString);
        }
    }
}
