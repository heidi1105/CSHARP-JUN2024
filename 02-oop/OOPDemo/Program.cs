// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


Employee staff1 = new Employee("Heidi Chen");
staff1.ShowStatus();

Console.WriteLine(staff1.Name);

staff1.Skills.Add("Make coffee");

Console.WriteLine(staff1.Skills[0]);