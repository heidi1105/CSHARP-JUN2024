// 1. Create the folder
// 2. open terminal in that folder
// 3. dotnet new console

// 1. dotnet new console -o FundamentalDemo
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

/* 1. Variables 
Naming Convention:
    PascalCase for Class Method/Variable 
    camelCase for local variables / parameters
*/

string title = "First day in C#";
int likes = 50;
bool isExcited = true;
char level = 'A';

Console.WriteLine(title);
Console.WriteLine(likes);
Console.WriteLine(isExcited);
Console.WriteLine(level);

Console.WriteLine($"Title: {title} | Likes: {likes} | isExcited: {isExcited} | Level: {level}");

Console.WriteLine("Title: {0} Likes: {1}| ", title, likes);

/* 
    2. Random & Conditionals
*/

if (likes > 10)
{
    Console.WriteLine("The post has a lot of likes");
}
else
{
    Console.WriteLine("The post needs more likes");
}

Random rand = new Random();
int luckyNum = rand.Next(100);
Console.WriteLine(luckyNum);


/* 
   Loops
*/


for(int i = 1; i< 5; i++)
{
    Console.WriteLine(i);
}

int j = 1;

while(j< 5)
{
    Console.WriteLine(j);
    j++;
}

/* 
    3. Arrays & List
*/

// Fixed array
int[] numArray = new int[5]; // instantiate an empty array with 5 elements
int[] numArray2 = new int[]{1, 3, 5};
int[] numArray3 = {2, 4, 6};
int[] numArray4 = [1, 4, 6];

for(int i = 0; i< numArray4.Length; i++)
{
    Console.WriteLine(numArray4[i]);
}

// Dyanmic List
// List<string> mySkills = new List<string>();
// List<string> mySkills = new();
// List<string> mySkills = new()
// {
//     "Python",
//     "JS"
// };
List<string> mySkills = ["Flask", "React"];
mySkills.Add("Bootstrap");
mySkills.Add("Tailwind");

for(int i = 0; i < mySkills.Count; i++)
{
    Console.WriteLine($"{i} : {mySkills[i]}");
}

foreach(string skill in mySkills)
{
    Console.WriteLine(skill);
}

Dictionary<string, string> profile = new();
profile.Add("Name", "Pepper");
profile.Add("Language", "C#");

Console.WriteLine($"Name: {profile["Name"]}");
Console.WriteLine($"Language: {profile["Language"]}");

foreach(KeyValuePair<string,string> entry in profile)
{
    Console.WriteLine($"{entry.Key} - {entry.Value}");
}

static void Greeting(string name = "Anonymous")
{
    Console.WriteLine($"Hi, {name}");
}

static string GreetMessage()
{
    return "Hi from GreetMessage";
}

Greeting();
Greeting("Pepper"); // print out "hi"


//GreetMessage(); // return a string
Console.WriteLine(GreetMessage());


Console.WriteLine("What is your name?");
string nameInput = Console.ReadLine();
Greeting(nameInput);


Console.WriteLine("Type a number, then hit enter: ");
string NumberInput = Console.ReadLine(); // returning a string
int converted = Convert.ToInt32(NumberInput);
Console.WriteLine(10 + converted);



// Implicit Casting - no lossy conversion
int intNum = 8; // 8
double intNumToDouble = intNum; // 8.0

Console.WriteLine(intNumToDouble);


// Explict casting - with lossy conversion
double doubleNum = 1.99; // 1.99
int doubleNumToInt = (int) doubleNum; // 1
Console.WriteLine(doubleNumToInt);