using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public DbSet<User> User { get; set; }
        public DbSet<Diary> Diary { get; set; }
        public DbSet<Book> Book { get; set; }
    }
}
