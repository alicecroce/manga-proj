using manga_project;
using manga_project.Repository;
using Microsoft.Extensions.DependencyInjection;

var appDbContext = new AppDbContext();


var serviceProvider = new ServiceCollection()
    .AddSingleton<AppDbContext>()
    .AddSingleton<CharacterRepository>()
    .BuildServiceProvider();

var characterRepository = serviceProvider.GetService<CharacterRepository>();
var unitOfWork = new UnitOfWork(characterRepository);

unitOfWork.Work();