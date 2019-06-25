using GorgeShipping.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace GorgeShipping.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<TelNo> TelephoneNumbers{ get; set; }
        public DbSet<Address> Addresses { get; set; }

    }
}
