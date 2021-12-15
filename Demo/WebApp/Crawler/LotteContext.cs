using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawler
{
    class LotteContext : DbContext
    {
        //public LotteContext(DbContextOptions options) : base(options) { }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Number> Numbers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-P4GDIPQ9;Initial Catalog=Lotte;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Province>().HasKey(p => new { p.Id });
        }
    }
}
