using System;
using Microsoft.EntityFrameworkCore;

namespace loginApp.Models {
    public class MyProjectContext : DbContext {
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite("Data source=database/db.db");
        }
        public DbSet<UserModel> User { get; set; }
    }
}