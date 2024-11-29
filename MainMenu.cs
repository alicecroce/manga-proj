using manga_project.SeedWork;
using Microsoft.Data.SqlClient;
using static System.Console;

namespace manga_project
{
    public class MainMenu(SubMenu characterSubMenu) : IDisposable, IAsyncDisposable
    {
        public void Dispose()
        {
            characterSubMenu.Dispose();
        }

        public ValueTask DisposeAsync()
        {
            throw new NotImplementedException();
        }

        public void Render()
        {
            while (true)
            {
                WriteLine(  "\r\n Choose an operation on Manga: " +
                            "\r\n (1) Manage Manga" +
                            "\r\n (2) Manage Author" +
                            "\r\n (3) Manage Character" +
                            "\r\n (4) Manage MangaCharacter " +
                            "\r\n (5) Useful Queies" +
                            "\r\n (6) Exit");
                
                var choice = ReadLine();

                switch (choice)
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        characterSubMenu.Work();
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    case "6":
                        return;
                    default:
                        WriteLine("Invalid choice, please try again!");
                        break;
                }
            }
        }
    }
}
