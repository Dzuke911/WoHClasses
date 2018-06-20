﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using WoH_classes.BasicClasses;
using WoH_classes.Enums;
using WoH_classes.Managers;
using WoH_classes.Maps;
using WohClassesVisualiser.Models;

namespace WohClassesVisualiser.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(MapFactory<Hex> mapFactory)
        {
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

            return Json(map.ToJson());
        }

        [HttpGet]
        public async Task<JsonResult> GetUnits()
        {
            Map<Hex> map = _mapFactory.CreateMap(MapShape.Circle, 5);
            UnitsManager um = new UnitsManager();

            UnitTypeAttributesManager utaManager = await UnitTypeAttributesManager.GetInstance("GameData/UnitTypeAttributes.json");
            UnitTypesManager utManager = await UnitTypesManager.GetInstance("GameData/UnitTypes.json", utaManager);

            PlayersManager pm = new PlayersManager();

            pm.CreatePlayers(1);

            Unit u = new Unit(utManager.GetUnitType("GermanTank"), map.GetHex(0, 0), pm.GetPlayer(0));

            um.AddUnit(u);

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
