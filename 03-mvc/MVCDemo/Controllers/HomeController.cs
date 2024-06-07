using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCDemo.Models;

namespace MVCDemo.Controllers;



public class HomeController : Controller
{
    private static List<Entry> fakeEntryDB = [];

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
    // From W1D4

    /*
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
                HttpContext.Session.SetString("Name", newEntry.FullName);
                return View(newEntry); // Show the result
            }
        }
    */


    [HttpPost("raffle/process")] // matching the form action
    public IActionResult RaffleProcess(Entry newEntry) // Set all the input value into newEntry according to the Model
    {   
        if(!ModelState.IsValid) // Opposite to the platform, if it is NOT valid
        {
            List<string> allHoros = ["Aries", "Taurus", "Gemini", "Cancer", "Leo", "Virgo", "Libra", "Scorpio", "Sagittarius", "Aquarius", "Pisces"];
            ViewBag.AllHoros = allHoros;
            return View("RaffleEntry");
        }
        else // If the form is valid
        {
            // Add to the tempDb
            fakeEntryDB.Add(newEntry);
            // .SaveChanges();
            HttpContext.Session.SetString("Name", newEntry.FullName);
            return RedirectToAction("RaffleResultTable"); // Show the result
        }
    }

    [HttpGet("raffle/results")]
    public ViewResult RaffleResultTable()
    {
        return View(fakeEntryDB);
    }

    // ----------- Session Record page -------------
    [HttpGet("count")]
    public ViewResult SessionRecord()
    {
        // Option 1
        /*
            if(HttpContext.Session.GetInt32("Count") == null)
            {
                HttpContext.Session.SetInt32("Count", 1);
            }
            else
            {
                int? CountFromSession = HttpContext.Session.GetInt32("Count");
                HttpContext.Session.SetInt32("Count", ((int)CountFromSession) +1);
            }
        */
        // Option 2
        int CountFromSession = HttpContext.Session.GetInt32("Count") ?? 0; // if it is null, return 0
        HttpContext.Session.SetInt32("Count", CountFromSession + 1);
        
        return View();
    }

    // Clear session
    [HttpPost("session/clear")]
    public RedirectToActionResult ClearSession()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
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
