using manga_project;
using manga_project.Domain;
using manga_project.Interviewers;
using manga_project.Menus;
using manga_project.Repository;
using manga_project.SeedWork;
using Microsoft.Extensions.DependencyInjection;

var appDbContext = new AppDbContext();

// Repository e Interviewer esistenti
var characterRepository = new CharacterRepository(appDbContext);
var characterInterviewer = new CharacterInterviewer();

var mangaCharacterRepository= new MangaCharacterRepository(appDbContext);
var mangaCharacterInterviewer= new MangaCharacterInterviewer();

// Repository per QueriesMenu
var queriesRepository =new QueriesRepository(appDbContext);


var characterSubMenu = new SubMenu<Character>(nameof(Character), characterRepository, characterInterviewer);
var mangaCharacterSubMenu = new SubMenu<MangaCharacter>(nameof(MangaCharacter), mangaCharacterRepository, mangaCharacterInterviewer);

// Crea l'istanza di QueriesMenu
var queriesSubMenu = new QueriesMenu(queriesRepository);

using var unitOfWork = new MainMenu(characterSubMenu, mangaCharacterSubMenu,queriesSubMenu);

unitOfWork.Render();