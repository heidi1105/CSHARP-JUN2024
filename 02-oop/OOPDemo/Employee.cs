public class Employee
{
    // ----------- 1. Attributes, Fields, Properties ------------

    private string _name;     // private field : _camelCase
    public string Name // property : PascalCase
    {
        get {return _name;} //To read the property
        set {_name = value;} // To set the property
    }

    // Auto-implemented Properties
    public string Role {get; set;}
    public int BrainCell{get; set;} = 10;
    public List<string> Skills{get; set;} = new();


    // Properties with more logic
    public string Email
    {
        get
        {
            string username = Name.ToLower().Replace(" ", "_");
            return $"{username}@codingdojo.com";
        }
    }


    // ----------- 2. Constructor ------------
    public Employee(string name, string role = "Staff") // camelCase for parameters
    {
        Name = name;
        Role = role;
    }

    // ----------- 3. Methods ------------
    public virtual void ShowStatus() // to be overrided 
    {
        Console.WriteLine("=========Status=========");
        Console.WriteLine($"Name : {Name}");
        Console.WriteLine($"Role : {Role}");
        Console.WriteLine($"Email : {Email}");
        Console.WriteLine($"BrainCell : {BrainCell}");
    }

    public void Teach(Employee targetStaff)
    {
        Console.WriteLine($"{Name} is teaching {targetStaff.Name}");
        BrainCell += 2;
        targetStaff.BrainCell += 1;
    }
}