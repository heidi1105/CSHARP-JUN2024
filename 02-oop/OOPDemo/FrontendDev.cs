public class FrontendDev : Employee, ICanCode
{
    public string CodingLanguage {get; set;}

    // Attribute for the Interface
    public string OS{get; set;} = "MacOS";


    public FrontendDev(string name) : base(name, "Frontend Developer" )
    {
        CodingLanguage = "JS";
    }

    public override void ShowStatus()
    {
        base.ShowStatus(); // invoke the ShowStatus in Employee class
        Console.WriteLine($"Coding Language: {CodingLanguage}");
        Console.WriteLine($"OS: {OS}");
    }

    public void Debug()
    {
        Console.WriteLine($"{Name} is inspecting elements");
    }
}