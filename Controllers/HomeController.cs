using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using WhosThatPokemon.Models;

namespace WhosThatPokemon.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var jsonString = System.IO.File.ReadAllText("pokedex.json");
            var pokedex = JsonSerializer.Deserialize<List<Pokemon>>(jsonString);
            var rand = new Random();
            return View(pokedex[rand.Next(pokedex.Count())]);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}