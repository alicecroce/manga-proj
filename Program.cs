using manga_project;
using manga_project.Domain;
using manga_project.Interviewers;
using manga_project.Menus;
using manga_project.Repository;
using manga_project.SeedWork;
using Microsoft.Extensions.DependencyInjection;

var appDbContext = new AppDbContext();
var characterRepository = new CharacterRepository(appDbContext);
var characterInterviewer = new CharacterInterviewer();

var characterSubMenu = new SubMenu<Character>(nameof(Character), characterRepository, characterInterviewer);
using var unitOfWork = new MainMenu(characterSubMenu);

unitOfWork.Render();