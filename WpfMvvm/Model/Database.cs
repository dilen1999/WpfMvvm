using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMvvm.Model
{
    public class Database:DbContext
    {
        public DbSet<student> Students { get; set; }
        private readonly string _path = @"C:\Users\tharsi\Desktop\WpfMvvm\WpfMvvm\WpfMvvm\DB\persons.db";

        protected override void
            OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite($"Data source={_path}");
    }
}
