using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using WoH_classes.BasicClasses;
using WoH_classes.Enums;
using WoH_classes.GameFactories;
using WoH_classes.Interfaces;
using WoH_classes.Managers;
using WoH_classes.Maps;
using Woh_Visualiser.Models;

namespace Woh_Visualiser.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IUnitTypeAttributesManager _unitTypeAttributesManager;
        private IUnitTypesManager _unitTypesManger;

        public HomeController(MapFactory<Hex> mapFactory, IUnitTypeAttributesManager unitTypeAttributesManager, IUnitTypesManager unitTypesManger)
        {
            _unitTypeAttributesManager = unitTypeAttributesManager;
            _unitTypesManger = unitTypesManger;
            _mapFactory = mapFactory;
        }

        private readonly MapFactory<Hex> _mapFactory;

        public IActionResult Index()
        {
            Map<Hex> map = _mapFactory.CreateMap(MapShape.Circle, 5);

            HomeModel model = new HomeModel() { Hexes = map.Hexes };

            return View(model);
        }

        [HttpGet]
        public JsonResult GetMap()
        {
            Map<Hex> map = _mapFactory.CreateMap(MapShape.Circle, 5);

            // ITS TEMPORARY!!!!!!!!!!!
            GameUnitsManager um = new GameUnitsManager();

            return Json(map.ToJson(um));
        }

        [HttpGet]
        public async Task<JsonResult> GetUnits()
        {
            const string playerId = "asd";
            Map<Hex> map = _mapFactory.CreateMap(MapShape.Circle, 5);
            GameUnitsManager um = new GameUnitsManager();

            GamePlayersManager pm = new GamePlayersManager(new GameTeamsFactory());
            Player p = new Player(playerId);

            pm.AddTeam(p);

            Unit u1 = new Unit(_unitTypesManger.GetUnitType("GermanTank"), map.GetHex(0, 0), p, HexDirection.Top);
            Unit u2 = new Unit(_unitTypesManger.GetUnitType("GermanTank"), map.GetHex(0, 1), p, HexDirection.BottomLeft);
            Unit u3 = new Unit(_unitTypesManger.GetUnitType("GermanTank"), map.GetHex(0, -1), p, HexDirection.TopRight);

            um.AddUnit(u1);
            um.AddUnit(u2);
            um.AddUnit(u3);

            var ret = um.ToJson();

            return Json(ret);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
