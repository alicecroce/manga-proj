using manga_project.Domain;

namespace manga_project.Repository
{
    public class CharacterRepository
    {
        private readonly AppDbContext _context;

        public CharacterRepository(AppDbContext context)
        {
            _context = context;
        }

        public void InsertCharacter(string name)
        {
            var character = new Character
            {
                Name = name
            };
            _context.Characters.Add(character);
            _context.SaveChanges();
        }

        public IEnumerable<Character> GetAllCharacters()
        {
            return _context.Characters.ToList();
        }
        
    }
}

