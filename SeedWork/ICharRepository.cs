using manga_project.Domain;

namespace manga_project.SeedWork
{
    public interface ICharRepository:IDisposable
    {
        public void InsertCharacter(string name);
        //public void Update(int id, string email);
        //public void Delete(int id);
        public IEnumerable<Character> GetCharacter();
        void Dispose();
    }
}
