using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WoH_classes.Accounts;
using WoH_classes.BasicClasses;
using WoH_classes.DataManagers;
using WoH_classes.Enums;
using WoH_classes.GameFactories;
using WoH_classes.GameManagers;
using WoH_classes.Interfaces;
using WoH_classes.Managers;
using WoH_classes.Maps;
using WoH_Data;
using Xunit;

namespace WoH_classes_Tests
{
    public  class BaseTestClass
    {
        private IServiceCollection _services;
        protected IGameDefaultsManager _gameDefaultsManager;

        public BaseTestClass()
        {
            _services = new ServiceCollection();

            _services.AddTransient(f => new MapFactory<Hex>());

            _services.AddSingleton<IGameDefaultsManager, GameDefaultsManager>(s => new GameDefaultsManager("GameData/GameDefaults.json"));

            _services.AddTransient<IGameTeamsFactory, GameTeamsFactory>(s => new GameTeamsFactory());
            _services.AddTransient<IGameUnitsManager, GameUnitsManager>(s => new GameUnitsManager());

            _services.AddTransient<IAuthentication, WoHAuthentication>(s => new WoHAuthentication(s.GetService<UserManager<ApplicationUser>>(), s.GetService<SignInManager<ApplicationUser>>(), s.GetService<WoHDbContext>()));

            _services.AddTransient<IGamePlayersManager, GamePlayersManager>(s => new GamePlayersManager(s.GetService<IGameTeamsFactory>()));
            _services.AddTransient<IGameManagersFactory, GameManagersFactory>(s => new GameManagersFactory(s.GetService<IGameTeamsFactory>()));

            _services.AddTransient<IGamesFactory, GamesFactory>(s => new GamesFactory(s.GetService<IGameManagersFactory>()));
            _services.AddTransient<IGamesManager, GamesManager>(s => new GamesManager(s.GetService<IGamesFactory>()));

            _gameDefaultsManager = _services.BuildServiceProvider().GetService<IGameDefaultsManager>();
        }
    }
}
