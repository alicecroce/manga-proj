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

        public IEnumerable<Character> GetCharacter() => ctx.Characters.ToList();
       
        public void Dispose() => ctx.Dispose();

    } 
}
    

