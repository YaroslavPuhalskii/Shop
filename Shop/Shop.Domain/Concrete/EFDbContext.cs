using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Text;
using Shop.Domain.Entities;

namespace Shop.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}
