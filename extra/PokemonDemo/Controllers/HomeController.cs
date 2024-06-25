using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PokemonDemo.Models;
using PokemonDemo.Services;


namespace PokemonDemo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        PokemonListResult result = await PokemonApiService.ProcessAllPokeAsync();
        ViewBag.result = result;
        return View(result);
    }

    [HttpGet("pokemons/{name}")]
    public async Task<IActionResult> PokeDetails(string name)
    {
        Pokemon onePoke = await PokemonApiService.ProcessPokemonAsync($"https://pokeapi.co/api/v2/pokemon/{name}");
        return View(onePoke);
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
