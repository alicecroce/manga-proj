using manga_project.Domain;
using manga_project.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace manga_project.Repository
{
    public class CharacterRepository(AppDbContext ctx) : IRepository<Character> ,IDisposable
    {
        public void Insert(Character entity)
        {
            ctx.Characters.Add(entity);
            ctx.SaveChanges();
        }

        public void Update(Character entity)
        {
            var character = ctx.Characters.Find(entity.CharacterId);
            if (character == null) return;
            character.Name = entity.Name;
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            var character = ctx.Characters.Find(id);
            if (character == null) return;
            ctx.Characters.Remove(character);
            ctx.SaveChanges();
        }

        public IEnumerable<Character> GetAll() => ctx.Characters.ToList();
       
        public void Dispose() => ctx.Dispose();

    } 
}
    

