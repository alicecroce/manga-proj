using manga_project.Repository;
using manga_project.Domain;
using Microsoft.Data.SqlClient;
using static System.Console;

namespace manga_project
{
    public class UnitOfWork : IDisposable
    {
        private readonly CharacterRepository _characterRepository;

        public UnitOfWork(CharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public void Dispose()
        {
           
        }

        public void Work()
        {
            try
            {
                InternalWork();
            }
            catch (Exception ex)
            {
                WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private void InternalWork()
        {
            while (true)
            {
                WriteLine("\r\n Choose an operation on Manga: " +
                    "\r\n (1) Insert Character " +
                    "\r\n (2) Read All Character " +
                    "\r\n (3) Update Character " +
                    "\r\n (4) Delete Character " +
                    "\r\n (5) Exit");
                var choice = ReadLine();

                switch (choice)
                {
                    case "1":
                        
                        //InsertCharacter();
                        break;
                    case "2":
                        //ReadAllCharacters();
                        break;
                    case "3":
                        //UpdateCharacter();
                        break;
                    case "4":
                        //DeleteCharacter();
                        break;
                    case "5":
                        return;
                    default:
                        WriteLine("Invalid choice, please try again!");
                        break;
                }
            }
        }


    }
}
