using Microsoft.AspNetCore.Mvc;

namespace WebDemo.Controllers;

[Route("api")]
public class FirstController : Controller
{
    [HttpGet]
    [Route("")]
    public string Index()
    {
        return "Hello C#!";
    }

    [HttpGet("test")]
    public string TestRoute()
    {
        return "Testing route";
    }

    [HttpGet("lucky/{num}")]
    public string LuckyPage(int num)
    {
        return $"Your lucky number is {num}";
    }


}