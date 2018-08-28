using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WoH_classes.Accounts;
using WoH_classes.BasicClasses;
using WoH_classes.DataManagers;
using WoH_classes.GameFactories;
using WoH_classes.GameManagers;
using WoH_classes.Interfaces;
using WoH_classes.Managers;
using WoH_classes.Maps;
using WoH_Data;
using WoH_GameData.GameDataFacade;

namespace WoH_classes.Facade
{
    public static class FacadeRegistration
    {
        public static IConfiguration Configuration { get; set; }

        public static void ConfigureServices(IServiceCollection services)
        {
            WoHDatabaseFacade.Configuration = Configuration;
            WoHDatabaseFacade.ConfigureServices(services);
            WoHDatabaseFacade.InitDatabase();

            GameDataFacade.Configuration = Configuration;
            GameDataFacade.ConfigureServices(services);
            
            services.AddTransient(f => new MapFactory<Hex>());

            //services.AddSingleton<IUnitTypeAttributesManager, UnitTypeAttributesManager>(s => new UnitTypeAttributesManager("GameData/UnitTypeAttributes.json"));
            //services.AddSingleton<IUnitTypesManager, UnitTypesManager>(s => new UnitTypesManager("GameData/UnitTypes.json",s.GetService<IUnitTypeAttributesManager>()));
            services.AddSingleton<IGameDefaultsManager, GameDefaultsManager>(s => new GameDefaultsManager("GameData/GameDefaults.json"));

            services.AddTransient<IGameTeamsFactory, GameTeamsFactory>(s => new GameTeamsFactory());
            services.AddTransient<IGameUnitsManager, GameUnitsManager>(s => new GameUnitsManager());

            services.AddTransient<IAuthentication, WoHAuthentication>(s => new WoHAuthentication(s.GetService<UserManager<ApplicationUser>>() , s.GetService<SignInManager<ApplicationUser>>()));

            services.AddTransient<IGamePlayersManager, GamePlayersManager>(s => new GamePlayersManager(s.GetService<IGameTeamsFactory>()));
            services.AddTransient<IGameManagersFactory, GameManagersFactory>(s => new GameManagersFactory(s.GetService<IGameTeamsFactory>()));

            services.AddTransient<IGamesFactory, GamesFactory>(s => new GamesFactory(s.GetService<IGameManagersFactory>()));
            services.AddTransient<IGamesManager, GamesManager>(s => new GamesManager(s.GetService<IGamesFactory>()));
        }
    }
}
