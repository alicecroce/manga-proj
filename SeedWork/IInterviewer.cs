namespace manga_project.SeedWork
{
    public interface IInterviewer<T>
    {
        T Create();
        T Update();
    }
}
