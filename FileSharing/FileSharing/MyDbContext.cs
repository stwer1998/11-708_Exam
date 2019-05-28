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
       
    }
}
