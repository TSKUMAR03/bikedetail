using Bike.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bike.Domain.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<BikeDetails> Details { get; set; }
        public DbSet<SalesManDetails> SalesManTable { get; set; }
         


    }
}
 