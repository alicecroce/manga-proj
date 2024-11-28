using manga_project.Repository;
using manga_project.Domain;
using Microsoft.Data.SqlClient;
using static System.Console;
using Azure;
using static System.Runtime.InteropServices.JavaScript.JSType;
using manga_project.SeedWork;

namespace manga_project
{
    public class UnitOfWork(ICharRepository characterRepository) : IDisposable
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
                            InsertCharacter();
                            break;
                        case "2":
                            ReadAllCharacters();
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

        private void InsertCharacter()
        {
            Write("Insert name character: ");
            var charName = ReadLine();


            if (string.IsNullOrEmpty(charName))
            {
                WriteLine("Please enter a valid user name or email");
                return;
            }

            characterRepository.InsertCharacter(charName);
        }

        private void ReadAllCharacters()
        {
            foreach (var character in characterRepository.GetCharacter()) WriteLine(character.ToString());
        }


    }
}
