using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WoH_GameData.DataLoader;
using WoH_GameData.Interfaces;
using WoH_GameData.DataStorage;

namespace WoH_GameData.GameDataFacade
{
    public static class GameDataFacade
    {
        public static IConfiguration Configuration { get; set; }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGameDataLoader,GameDataLoader>( s => new GameDataLoader());
            services.AddSingleton<IGameDataStorage, GameDataStorage>(s => s.GetService<IGameDataLoader>().GetStorage(Configuration.GetConnectionString("GameEntities")));
        }
    }
}
