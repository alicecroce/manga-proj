using manga_project;
using manga_project.Menus;
using manga_project.Repository;
using manga_project.SeedWork;
using Microsoft.Extensions.DependencyInjection;

var appDbContext = new AppDbContext();
var characterRepository = new CharacterRepository(appDbContext);
var characterSubMenu = new SubMenu(characterRepository);
using var unitOfWork = new MainMenu(characterSubMenu);

unitOfWork.Render();