using Microsoft.EntityFrameworkCore;

namespace MyProject2.Model
{
    public class AppDbContext : DbContext
    {
        public DbSet<Book> Book { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=mysql-symptoms.mysql.database.azure.com;database=symptoms;uid=alexey;pwd=Ibvfyjdcr99;");
        }
    }
}