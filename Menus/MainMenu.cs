using manga_project.Domain;
using manga_project.SeedWork;
using Microsoft.Data.SqlClient;
using static System.Console;

namespace manga_project.Menus
{
    public class MainMenu(SubMenu<Character> characterSubMenu, SubMenu<MangaCharacter> mangaCharacterSubMenu, QueriesMenu queriesMenu ) : IDisposable, IAsyncDisposable
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
                WriteLine("\r\n Choose an operation : " +
                            "\r\n (1) Manage Manga (usefull)" +
                            "\r\n (2) Manage Author (usefull)" +
                            "\r\n (3) Manage Character" +
                            "\r\n (4) Manage MangaCharacter " +
                            "\r\n (5) Useful Queries" +
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
                        mangaCharacterSubMenu.Work();
                        break;
                    case "5":
                        queriesMenu.Work();
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
