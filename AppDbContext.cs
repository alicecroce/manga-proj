using manga_project.Domain;
using Microsoft.EntityFrameworkCore;

namespace manga_project
{
    public class AppDbContext:DbContext
    {
        //Tabelle
        public DbSet<Character> Characters { get; set; }
        public DbSet<Manga> Manga { get; set; }
        public DbSet<MangaCharacter> MangaCharacter { get; set; }

        //Configuro il db
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string connectionString = "Server=ALICE-ASUS\\SQLEXPRESS;Database=Manga;TrustServerCertificate=True;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manga>()
                .HasMany(m => m.MangaCharacter)
                .WithOne(mc => mc.Manga)
                .HasForeignKey(mc => mc.MangaId);

            modelBuilder.Entity<Character>()
                .HasMany(c => c.MangaCharacter)
                .WithOne(mc => mc.Character)
                .HasForeignKey(mc => mc.CharacterId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
