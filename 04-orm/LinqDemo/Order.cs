#pragma warning disable CS8618
public class Order
{
    public string Type { get; set;}
    public List<Flavor> Flavors { get; set; } = new();

    public Order() { }

    public Order(string type, List<Flavor> flavors)
    {
        Type = type;
        Flavors = flavors;
    }

    public override string ToString()
    {
        string orderDetails = "";
        foreach (Flavor flavor in Flavors)
        {
            orderDetails += $" {flavor.Name}";
        }
        return $"{Type} : {orderDetails}";
    }
}




