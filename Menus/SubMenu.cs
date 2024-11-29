using manga_project.Domain;
using manga_project.SeedWork;
using Microsoft.Data.SqlClient;
using static System.Console;

namespace manga_project.Menus
{

    public class SubMenu(IRepository<Character> characterRepository) : IDisposable
    {

        public void Dispose()
        {
            characterRepository.Dispose();
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
                    "\r\n (1) Insert Character " +
                    "\r\n (2) Read All Character " +
                    "\r\n (3) Update Character " +
                    "\r\n (4) Delete Character " +
                    "\r\n (5) Exit");
                var choice = ReadLine();

                switch (choice)
                {
                    case "1":
                        InsertCharacter();
                        break;
                    case "2":
                        ReadAllCharacters();
                        break;
                    case "3":
                        UpdateCharacter();
                        break;
                    case "4":
                        DeleteCharacter();
                        break;
                    case "5":
                        return;
                    default:
                        WriteLine("Invalid choice, please try again!");
                        break;
                }

            }
        }

        private void InsertCharacter()
        {
            Write("Insert name character: ");
            var charName = ReadLine();


            if (string.IsNullOrEmpty(charName))
            {
                WriteLine("Please enter a valid user name or email");
                return;
            }

            characterRepository.Insert(new Character
            {
                Name = charName,
            });
        }

        private void ReadAllCharacters()
        {
            foreach (var character in characterRepository.GetAll()) WriteLine(character.ToString());
        }

        private void UpdateCharacter()
        {
            Write("Insert the Id to update: ");
            var id = ReadLine();

            Write("Insert the name to update: ");
            var name = ReadLine();


            if (int.TryParse(id, out var characterId) && !string.IsNullOrEmpty(name))
                characterRepository.Update(new Character
                {
                    CharacterId = int.Parse(id),
                    Name = name
                } );
            //non ha parentesi perchè ha solo una istruzione da seguire quindi figura inline
        }

        private void DeleteCharacter()
        {
            Write("Insert the Id to Delete: ");
            var id = ReadLine();

            if (int.TryParse(id, out var characterId))
                characterRepository.Delete(characterId);
            else
                WriteLine("Id is not valid");
        }
    }
}