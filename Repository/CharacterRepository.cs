using manga_project.Domain;
using manga_project.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace manga_project.Repository
{
    public class CharacterRepository(AppDbContext ctx) : ICharRepository,IDisposable
    {
        public void InsertCharacter(string name)
        {
            ctx.Characters.Add(new()
            {
                Name = name
            });
            ctx.SaveChanges();
        }

        public void UpdateCharacter(int id, string name)
        {
            var character = ctx.Characters.Find(id);
            if (character == null) return;
            character.Name = name;
            ctx.SaveChanges();
        }

        public void DeleteCharacter(int id)
        {
            var character = ctx.Characters.Find(id);
            if (character == null) return;
            ctx.Characters.Remove(character);
            ctx.SaveChanges();
        }

        public IEnumerable<Character> GetCharacter() => ctx.Characters.ToList();
       
        public void Dispose() => ctx.Dispose();

    } 
}
    

