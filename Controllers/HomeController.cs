using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using cardslanding.Models;
using cardslanding.Data;
using cardslanding.Data.Repositories;
using Microsoft.Extensions.Options;

namespace cardslanding.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IOptions<AppSettings> _config;

        public HomeController(ApplicationDbContext context,
                              IOptions<AppSettings> config)
        {
            _context = context;
            _config = config;
        }


        public IActionResult Index()
        {
            var model = new GamesViewModel();
            var gamesRepo = new GamesRepository(_context);
            model.Games = gamesRepo.GetAllPublicGames();
            model.GameURL = _config.Value.GameURL;

            return View(model);
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
