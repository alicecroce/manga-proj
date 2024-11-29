using manga_project.Domain;
using manga_project.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace manga_project.Repository
{
    public class MangaCharacterRepository(AppDbContext ctx) : IRepository<MangaCharacter>
    {

        public void Insert(MangaCharacter entity)
        {
            ctx.MangaCharacter.Add(entity);
            ctx.SaveChanges();
        }

        public void Update(MangaCharacter entity)
        {
            var mangaChar = ctx.MangaCharacter.Find(entity.MangaCharacterId);
            if (mangaChar == null) return;
            mangaChar.MangaId = entity.MangaId;
            mangaChar.CharacterId = entity.CharacterId;
            mangaChar.IsCrossover = entity.IsCrossover;
            ctx.SaveChanges();
        }
        public void Delete(int id)
        {
            var mangaCharacter = ctx.MangaCharacter.Find(id);
            if (mangaCharacter == null) return;
            ctx.MangaCharacter.Remove(mangaCharacter);
            ctx.SaveChanges();
        }

        public void Dispose() => ctx.Dispose();

        public IEnumerable<MangaCharacter> GetAll()
        {
            return ctx.MangaCharacter
                  .Include(mc => mc.Manga)
                  .Include(mc => mc.Character)
                  .ToList();

        }  

    }
}
