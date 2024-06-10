// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

List<Item> Items = new()
{
    new Item(1, "Milk", "Food", 5.29, new DateTime(2024, 07, 15)),
    new Item(2, "Soup Dumpling", "Food", 3.29, new DateTime(2024, 09, 01)),
    new Item(3, "Spicy Dumpling", "Food", 3.29, new DateTime(2023, 09, 01)), // expired
    new Item(4, "Ceviche", "Food", 12.49, new DateTime(2024, 04, 15)), // expired
    new Item(5, "Seaweed", "Food", 4.99, new DateTime(2025, 01, 20)),
    new Item(6, "Burger", "Food", 0, new DateTime(2024, 06, 11)),
    new Item(7, "Curved Monitor", "Electronics", 349.99, new DateTime(2034, 06, 09)),
    new Item(8, "Red Gaming Chair", "Furniture", 299, new DateTime(2029, 01, 01)),
    new Item(9, "Swing Chair", "Furniture", 249.49, new DateTime(2027, 03, 10))
};


// 1. Getting a single result based on criteria
Item milk = Items.First(item => item.Name == "Milk"); // Throw an exception if they cannot find a matching item
Console.WriteLine(milk);

Item? almondMilk = Items.FirstOrDefault(item => item.Name == "Almond Milk"); 
// If they cannot find the matching item, return null
Console.WriteLine(almondMilk == null ? "No item found" : almondMilk);

Item? dumpling = Items.FirstOrDefault(item => item.Name.Contains("Dumpling"));
Console.WriteLine(dumpling == null ? "No item found" : dumpling);
Console.WriteLine("=======================================");

// 2. Getting multiple results based on criteria
List<Item> affordableExpiredItems = Items
                                    .Where(item=> item.Price < 10 & item.ExpiryDate < DateTime.Today) // enumerable 
                                    .ToList();
affordableExpiredItems.ForEach(Console.WriteLine);
Console.WriteLine("=======================================");


// 3. Ordering / Top 3
List<Item> foodAccordingToPrice = Items
                                    .Where(item=> item.Category == "Food")
                                    .OrderBy(item=> item.Price)
                                    .ToList();
foodAccordingToPrice.ForEach(Console.WriteLine);
Console.WriteLine("=======================================");

List<Item> cheapest3Food = Items
                            .Where(item=> item.Category == "Food")
                            .OrderBy(item=> item.Price)
                            .Take(3)
                            .ToList();
cheapest3Food.ForEach(Console.WriteLine);
Console.WriteLine("=======================================");

// 4. Getting select pieces of data
List<string> FoodNames = Items
                            .Where(item=> item.Category == "Food")
                            .Select(item=> $"{item.Name} : ${item.Price}" ) 
                            .ToList();
FoodNames.ForEach(Console.WriteLine);

// 5. Sum / Max / Min / Average
double minPrice = Items.Min(item=> item.Price);
Console.WriteLine(minPrice);

// 6. Logical testing
// If any of the items free?
bool anyFreeItem = Items.Any(item => item.Price == 0); 
// if any of the condition is true, return true
Console.WriteLine(anyFreeItem);

// Does all items not expired?
bool allNotExpired = Items.All(item=> item.ExpiryDate > DateTime.Today); 
// only return true if ALL the items match the condition
Console.WriteLine(allNotExpired);



// ICECREAM EXAMPLE
Flavor jasmine = new("Jasmine", true);
Flavor matcha = new( "Matcha", true);
Flavor chocolate = new("Chocolate", true);
Flavor banana = new("Banana", true);
Flavor strawberry = new("Strawberry", true);
Flavor mangoStickyRice = new("Mango Sticky Rice", false);
Flavor peach = new("Peach", false);
Flavor watermelon = new("Watermelon", false);
Flavor pear = new("Pear", false);
Flavor wasabi = new("Wasabi", true);

List<Order> Orders = new()
{
    new("Sundae", [jasmine, matcha, wasabi]),
    new("Double Scoop", [watermelon, peach]),
    new("Icecream Flight", [banana, mangoStickyRice, jasmine, wasabi]),
    new("Sundae", [banana]),
    new("Sorbet Flight", [pear, watermelon, peach])
};


// 7. nested queries
// Return the list of Dairy Free order
List<Order> dairyFreeOrders = Orders
                                .Where(order => order.Flavors
                                    .All(flavor => !flavor.IsDairy))
                                .ToList();
dairyFreeOrders.ForEach(Console.WriteLine);

// Return a list of dairy Free order with 3 flavors
List<Order> dairyFreeThreeFlavor = Orders
                                .Where(order => order.Flavors.Count == 3 && 
                                    order.Flavors.All(flavor => !flavor.IsDairy))
                                .ToList();
dairyFreeThreeFlavor.ForEach(Console.WriteLine);