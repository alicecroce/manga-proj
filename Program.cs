using manga_project;
using manga_project.Repository;
using manga_project.SeedWork;
using Microsoft.Extensions.DependencyInjection;

var appDbContext = new AppDbContext();
ICharRepository characterRepository = new CharacterRepository(appDbContext);
using var unitOfWork = new UnitOfWork(characterRepository);

unitOfWork.Work();