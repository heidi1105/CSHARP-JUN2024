namespace MVCDemo.Models;

public class Skill
{
    public string Language{get; set;}

    public int Rating{get; set;}

    public Skill(string language, int rating)
    {
        Language = language;
        Rating = rating;
    }

}

