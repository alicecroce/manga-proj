using manga_project.Domain;

namespace manga_project.SeedWork
{
    public interface ICharRepository:IDisposable
    {
        public void InsertCharacter(string name);
        public void UpdateCharacter(int id, string name);
        public void DeleteCharacter(int id);
        public IEnumerable<Character> GetCharacter();
        void Dispose();
    }
}
