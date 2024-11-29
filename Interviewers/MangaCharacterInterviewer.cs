using manga_project.Domain;
using manga_project.SeedWork;
using static System.Console;

namespace manga_project.Interviewers
{
    internal class MangaCharacterInterviewer : IInterviewer<MangaCharacter>
    {
        public MangaCharacter Create()
        {
            Write("Insert MangaId: ");
            var mangaId = ReadLine();

            Write("Insert CharacterId: ");
            var characterId = ReadLine();

            Write("Is it a crossover? (true/false): ");
            var isCrossover = ReadLine()?.ToLower() == "true";

            if (int.TryParse(mangaId, out var mangaIdInt) && int.TryParse(characterId, out var characterIdInt))
            {
                return new MangaCharacter
                {
                    MangaId = mangaIdInt,
                    CharacterId = characterIdInt,
                    IsCrossover = isCrossover
                };
            }

            return default;
        }

        public MangaCharacter Update()
        {
            Write("Insert MangaCharacterId to update: ");
            var id = ReadLine();

            Write("Insert new MangaId: ");
            var mangaId = ReadLine();

            Write("Insert new CharacterId: ");
            var characterId = ReadLine();

            Write("Is it a crossover? (true/false): ");
            var isCrossover = ReadLine()?.ToLower() == "true";

            if (int.TryParse(id, out var mangaCharacterId) && int.TryParse(mangaId, out var mangaIdInt) && int.TryParse(characterId, out var characterIdInt))
            {
                return new MangaCharacter
                {
                    MangaCharacterId = mangaCharacterId,
                    MangaId = mangaIdInt,
                    CharacterId = characterIdInt,
                    IsCrossover = isCrossover
                };
            }

            return default;
        }
    }
}