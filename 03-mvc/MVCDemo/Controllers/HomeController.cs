using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCDemo.Models;

namespace MVCDemo.Controllers;



public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        List<Skill> AllSkills = new()
        {
            new Skill("HTML", 10),
            new Skill("CSS", 9),
            new Skill("Python", 8),
            new Skill("JS", 10),
            new Skill("C#", 7)
        };
        return View(AllSkills);
    }

    [HttpGet("lucky/{num}")]
    public ViewResult LuckyPage(int num)
    {
        // return View(num);
        return View("LuckyPage", num);
    }

    [HttpGet("raffle/entry")]
    public ViewResult RaffleEntry()
    {
        List<string> allHoros = ["Aries", "Taurus", "Gemini", "Cancer", "Leo", "Virgo", "Libra", "Scorpio", "Sagittarius", "Aquarius", "Pisces"];
        ViewBag.AllHoros = allHoros;
        return View();
    }

    [HttpPost("raffle/process")] // matching the form action
    public ViewResult RaffleResult(Entry newEntry) // Set all the input value into newEntry according to the Model
    {   
        // To console out all the errors
        if (!ModelState.IsValid)
        {
           var message = string.Join(" | ", ModelState.Values
           .SelectMany(v => v.Errors)
           .Select(e => e.ErrorMessage));
           Console.WriteLine(message);
         }


        if(!ModelState.IsValid) // Opposite to the platform, if it is NOT valid
        {
            List<string> allHoros = ["Aries", "Taurus", "Gemini", "Cancer", "Leo", "Virgo", "Libra", "Scorpio", "Sagittarius", "Aquarius", "Pisces"];
            ViewBag.AllHoros = allHoros;
            return View("RaffleEntry");
        }
        else // If the form is valid
        {
            return View(newEntry); // Show the result
        }
    }


    [HttpGet("privacy")]
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
