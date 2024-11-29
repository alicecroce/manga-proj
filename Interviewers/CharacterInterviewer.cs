using manga_project.Domain;
using manga_project.SeedWork;
using static System.Console;


namespace manga_project.Interviewers
{
    internal class CharacterInterviewer : IInterviewer<Character>
    {
        public Character Create()
        {
            Write("Insert name character: ");
            var charName = ReadLine(); ;

            return new Character
            {
                Name = charName,
            };
        }

        public Character Update()
        {
            Write("Insert the Id to update: ");
            var id = ReadLine();

            Write("Insert the name to update: ");
            var name = ReadLine();


            if (int.TryParse(id, out var characterId) && !string.IsNullOrEmpty(name))
            {
                new Character
                {
                    CharacterId = int.Parse(id),
                    Name = name
                };
            }

            return default;
        }
    }
}
