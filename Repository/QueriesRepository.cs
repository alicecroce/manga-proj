using Microsoft.EntityFrameworkCore;

namespace manga_project.Repository
{
    public class QueriesRepository(AppDbContext ctx)
    {
        // Query 1: Get characters present in crossover between different mangas
        public void GetCrossoverCharacters()
        {
            var crossoverCharacters = from mangaCharacter in ctx.MangaCharacter
                                      where mangaCharacter.IsCrossover.Equals(true)
                                      select mangaCharacter.Character.Name;
            foreach (var crossoverCharacter in crossoverCharacters)
            {
                Console.WriteLine(crossoverCharacter);
            }

        }

        // Query 2: Find mangas with more than a certain number of characters
        public void GetMangasWithMoreThanXCharacters(int minCharacterCount)
        {
            var mangasWithMoreThanCharacters = from m in ctx.Manga
                                               where m.MangaCharacter.Count() > minCharacterCount
                                               select m.Title;


            foreach (var manga in mangasWithMoreThanCharacters)
            {
                Console.WriteLine(manga);
            }
        }
        //Query 3: Find mangas containing characters with similar 
        public void GetMangasWithCharactersSimilarNames(string namePart)
        {
            var mangas = from mc in ctx.MangaCharacter
                         join c in ctx.Characters on mc.CharacterId equals c.CharacterId
                         where c.Name.Contains(namePart)
                         join m in ctx.Manga on mc.MangaId equals m.MangaId
                         select m;

            foreach (var manga in mangas)
            {
                Console.WriteLine(manga);
            }

        }
       
    }
}
