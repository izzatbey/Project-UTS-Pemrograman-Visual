using Microsoft.EntityFrameworkCore;
using Project_UTS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_UTS.Config
{
    public class DatabaseContext : DbContext
    {
        private static string ConnectionURL = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=db_perpustakaan; Integrated Security=True";

        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionURL);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Buku> Bukus { get; set; }
        public DbSet<Peminjaman> Peminjamans { get; set; }
    }
}
