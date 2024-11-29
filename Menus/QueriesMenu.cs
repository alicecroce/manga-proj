using manga_project.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using static System.Console;


namespace manga_project.Menus
{
    public class QueriesMenu(QueriesRepository queryRepo)
    {
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
                WriteLine("\r\n Select a query to run: " +
                    "\r\n (1) Get characters present in crossover between different mangas " +
                    "\r\n (2) Find mangas with more than a certain number of characters " +
                    "\r\n (3) Find mangas containing characters with similar names" +
                    "\r\n (4) Sum of characters in crossover by author (usefull)" +
                    "\r\n (5) Exit");
                var choice = ReadLine();

                switch (choice)
                {
                    case "1":
                        queryRepo.GetCrossoverCharacters();
                        break;
                    case "2":
                        Console.WriteLine("Input the number of the character: ");
                        var minCharacterCount=int.Parse(ReadLine());

                        queryRepo.GetMangasWithMoreThanXCharacters(minCharacterCount);
                        break;
                    case "3":
                        Console.WriteLine("Input a name of a character: ");
                        var namePart = ReadLine();

                        queryRepo.GetMangasWithCharactersSimilarNames(namePart);
                        break;
                    case "4":
                        Console.WriteLine("Sorry,this section is usefull");
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
