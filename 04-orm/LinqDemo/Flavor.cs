public class Flavor
{
    public string Name { get;set; }
    public bool IsDairy { get;set; }

    public Flavor (string name, bool isDairy)
    {
        Name = name;
        IsDairy = isDairy;
    }
}