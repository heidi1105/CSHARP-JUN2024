public class QATester : Employee
{
    public bool CanCreateTest{get; set;} = true;

    public QATester(string name):base(name, "QA Tester")
    {}

    public override void ShowStatus()
    {
        base.ShowStatus();
        Console.WriteLine($"Can create test? : {CanCreateTest}");
    }
}