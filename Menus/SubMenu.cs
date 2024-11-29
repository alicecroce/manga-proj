using manga_project.SeedWork;
using Microsoft.Data.SqlClient;
using static System.Console;

namespace manga_project.Menus
{

    public class SubMenu<T>(string entity, IRepository<T> repository, IInterviewer<T> interviewer) : IDisposable
    {

        public void Dispose()
        {
            repository.Dispose();
        }

        public void Work()
        {
            try
            {
                InternalWork();
            }
            catch (SqlException exception)
            {
                WriteLine("An error occurred while executing the database operation. {0}", exception);
            }
            catch (Exception e)
            {
                WriteLine("An error occurred while executing the operation. {0}", e);
                throw;
            }
            return;

            void InternalWork()
            {
                WriteLine("\r\n Choose an operation on Manga: " +
                    "\r\n (1) Insert {0} " +
                    "\r\n (2) Read All {0} " +
                    "\r\n (3) Update {0}" +
                    "\r\n (4) Delete {0}" +
                    "\r\n (5) Exit", entity);
                var choice = ReadLine();

                switch (choice)
                {
                    case "1":
                        Insert();
                        break;
                    case "2":
                        ReaAll();
                        break;
                    case "3":
                        Update();
                        break;
                    case "4":
                        Delete();
                        break;
                    case "5":
                        return;
                    default:
                        WriteLine("Invalid choice, please try again!");
                        break;
                }

            }
        }

        private void Insert()
        {
            var entity = interviewer.Create();
            repository.Insert(entity);
        }

        private void ReaAll()
        {
            foreach (var entity in repository.GetAll()) WriteLine($"{entity}");
        }

        private void Update()
        {
            var entity = interviewer.Update();
            repository.Update(entity);
        }

        private void Delete()
        {
            Write("Insert the Id to Delete: ");
            var id = ReadLine();

            if (int.TryParse(id, out var realId))
                repository.Delete(realId);
            else
                WriteLine("Id is not valid");
        }
    }
}