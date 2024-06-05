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
        return View();
    }

    [HttpGet("{**path}")]
    public ViewResult ConstructionPage()
    {
        return View("Elsewhere");
    }

}