# Notes on CRUD

## 1. Project setup
- Add the 2 packages (MySQL & efCore design)
  - 
  - [NamingConvention](https://www.nuget.org/packages/EFCore.NamingConventions) package is optional
- Add the connection string in appsettings.json (Follow the platform and update your password & db)
- Create Context file (Name must end with Context)
  ```cs
    namespace CRUDDemo.Models; // Add the correct namespace

    public class MyContext : DbContext 
    {   
        public MyContext(DbContextOptions options) : base(options) { }    
        
        // public DbSet<Trip> Trips { get; set; } 
        // Need to add this after Model is created
    }
  ```
  | Code | Usage |
  | -- | ---- |
  | #pragma warning disable CS8618 | We can disable our warnings safely because we know the framework will assign non-null values when it constructs this class for us. |
  | public class MyContext : DbContext | MyContext class represents a session with our MySQL database, allowing us to query for or save data | 
  |: DbContext | DbContext is a class that comes from EntityFramework to inherit |
  | public MyContext(DbContextOptions options) : base(options) { } | constructs our context upon initialization | 
  | public DbSet<Monster>   | every model in our project that is making a table, DBSet is Enumerable that allows Linq| 
  | public DbSet<Monster> ``` Monsters```  | table name -- plural for mySQL convention , Pascal for C# convention| 


- Add the context in the builder service (in Program.cs)
    ```cs
    // The following must be before builder.build()
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<MyContext>(options =>
    {
        options
            .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            .UseSnakeCaseNamingConvention(); // this is optional : to make it snake_case in MySQL
    });
    ```


## 2. Models & DB
- Add Model & Add the DbSet on Context file as well
  ```cs
    // Add namespace & using packages

    public class Trip
    {
        [Key] // To specify Primary key
        public int Id{get; set;} // Can call it TripId as well as long as it is called Id at the end

        [Required]
        [MinLength(3, ErrorMessage ="Location must be at least 3 characters long")]
        [Column(TypeName ="VARCHAR(255)")] // To specify Datatype in SQL
        public string Location{get; set;}

        [Required]
        [MaxLength(255)] // MaxLength can make it VARCHAR as well
        [Display(Name ="Image URL")]
        public string ImageUrl{get; set;}

        public string Description{get; set;}

        [DataType(DataType.Date)] // To display the form as Date
        [Display(Name ="Start Date")] // To update the label
        public DateOnly StartDate{get; set;}

        [Required]
        [Display(Name ="Length of the trip")]
        public int? TripLength{get; set;}

        [DefaultValue(false)]
        public bool IsConfirmed{get; set;}

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
    
  ``` 

    ```s
        dotnet ef migrations add FirstMigration           -- to add the Migration file
        dotnet ef database update                         -- To update the database

        If there is any error, add -v to see the error
    ```

## 3. CRUD
### 3.0 Setup
- Add the controller with context
  ```cs
    namespace CRUDDemo.Controllers;

    public class TripController : Controller
    {
        private MyContext _context;

        public TripController(MyContext context)
        {
            _context = context;
        }
    }
  ```
- Create the corresponding folder for the View

### 3.1 Create
- CreateForm : Refer to DojoSurvey with validation
  ```html
    @model Trip

    <form asp-action="NewTripProcess" asp-controller="Trip" method="POST">
        <div class="mb-3">        
            <label asp-for="Location"></label>        
            <input asp-for="Location">        
            <span asp-validation-for="Location"></span>    
        </div>  
    ```
- Process Create
  ```csharp
    [HttpPost("trips/new")]
    public IActionResult NewTripProcess(Trip newTrip)
    {
        if(!ModelState.IsValid) 
        {
            // if the form is invalid, return the view for err messages
            return View("NewTripForm");
        }
        else 
        {
            // if the form is valid, Add the trip to the DbSet
            _context.Trips.Add(newTrip);
            _context.SaveChanges(); // Save the change for the DB
            return RedirectToAction("Dashboard", "Trip"); 
            // Redirect with also the controller name 
        }
    }

  ```
### 3.2 Dashboard
- Think about the datatype we need for the model
- Get the List from the DB
- Pass it over to cshtml 
- Display it using foreach 

### 3.3 Details
- Get the id from route
- Use the id to get the item from the db
- Pass it over to cshtml
- Display it using @Model

### 3.4 Edit
- Edit form : 
  - Action will be the same as Details
  - cshtml will be the same as CreateForm except for the asp-action and need to add the asp-route-id
- Process edit:
  - When the form is invalid, make sure the updatedTrip include the Id ``` updatedTrip.Id = tripId ```
  - And ``` return View("EditForm", updatedTrip); ```
  - When the form is valid, update the trip from DB for each attribute and save it
  - If you want to redirect to Details, make sure you add the route. 
    ``` return RedirectToAction("DetailsPage", new {tripId = tripId}); ```

### 3.5 Delete
- Create the form to make it a post route
- Create the action for DeleteProcess (Find it using the id, then remove it and save it)