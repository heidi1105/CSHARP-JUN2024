public class Item
{
    public int Id{get; set;}
    public string Name{get; set;}
    public string Category{get; set;}
    public double Price{get; set;}
    public DateTime ExpiryDate{get; set;}

    public Item(int id, string name, string cat, double price, DateTime expDate)
    {
        Id = id;
        Name = name;
        Category = cat;
        Price = price;
        ExpiryDate = expDate;
    }


    public override string ToString()
    { // @ --> raw string - verbatim string, will ignore escape characters
        return $@"{Id} : {Name} ${Price} ({Category}) | ExpDate: {ExpiryDate.ToShortDateString()} 
            ";
    }
}