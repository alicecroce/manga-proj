using manga_project.Domain;
using Microsoft.EntityFrameworkCore;

namespace manga_project
{
    public class AppDbContext:DbContext
    {
        //Tabelle
        public DbSet<Character> Characters { get; set; }

        //Configuro dil db
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string connectionString = "Server=ALICE-ASUS\\SQLEXPRESS;Database=Manga;TrustServerCertificate=True;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
