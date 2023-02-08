using Microsoft.EntityFrameworkCore;

namespace minitwit_backend.Data
{
    internal sealed class MinitwitDBContext : DbContext
    {

        public DbSet<Message> Messages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) {
            dbContextOptionsBuilder.UseSqlite("Data Source=./Data/MiniTwitDB.db");
        }


    }
}
