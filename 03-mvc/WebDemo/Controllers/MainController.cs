using Microsoft.AspNetCore.Mvc;

namespace WebDemo.Controllers;

public class MainController : Controller
{
    [HttpGet("")]
    public ViewResult Index()
    {
        List<string> SkillList = ["HTML", "CSS", "Python", "JS", "C#"];
        ViewBag.AllSkills = SkillList; 
        ViewBag.Name="Pepper";
        ViewBag.Age = 15;
        return View();
    }


    [HttpGet("lucky/{num}")]
    public ViewResult LuckyPage(int num)
    {
        ViewBag.Num = num;
        return View();
    }

    [HttpGet("trymyluck")]
    public RedirectResult MoreThanTen()
    {
        int luckyNum = new Random().Next(10, 100);
        return Redirect($"/lucky/{luckyNum}"); // correspond to the URL
    }

    [HttpGet("tryagain")]
    public RedirectToActionResult LessThanTen()
    {
        int luckyNum = new Random().Next(10);
        // Correspond to the Action
        return RedirectToAction("LuckyPage", new {num = luckyNum});
    }

    [HttpGet("raffle/entry")]
    public ViewResult RaffleEntry()
    {
        List<string> allHoros = ["Aries", "Taurus", "Gemini", "Cancer", "Leo", "Virgo", "Libra", "Scorpio", "Sagittarius", "Aquarius", "Pisces"];
        ViewBag.AllHoros = allHoros;
        return View();
    }

    [HttpPost("raffle/process")] // matching the form action
    public ViewResult RaffleResult(string fullName, string horoscope, string introduction)
    {   
        ViewBag.Winning = new Random().NextSingle();
        ViewBag.FullName = fullName;
        ViewBag.Horoscope = horoscope;
        ViewBag.Introduction = introduction;
        return View();
    }

    [HttpGet("{**path}")]
    public ViewResult ConstructionPage()
    {
        return View("Elsewhere");
    }

}