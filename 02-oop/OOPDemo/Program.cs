// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


Employee staff1 = new Employee("Heidi Chen");
staff1.ShowStatus();

Console.WriteLine(staff1.Name);

staff1.Skills.Add("Make coffee");

Console.WriteLine(staff1.Skills[0]);

Employee staff2 = new Employee("Pepper");
staff1.Teach(staff2);

staff1.ShowStatus();
staff2.ShowStatus();

FrontendDev staff3 = new FrontendDev("John");

staff3.ShowStatus();

QATester staff4 = new QATester("Alex Miller");
staff4.ShowStatus();

staff3.Debug();
FrontendDev staff5 = new FrontendDev("FD1");
FrontendDev staff6 = new FrontendDev("FD2");
FrontendDev staff7 = new FrontendDev("FD3");

List<Employee> staffList = [staff1, staff2, staff3, staff4, staff5, staff6, staff7];
foreach(Employee e in staffList)
{
    Console.WriteLine(e.Name);
    
    if(e is FrontendDev fd)
    {
        Console.WriteLine($"{fd.Name} is using {fd.OS}");
        fd.Debug();
    }

}