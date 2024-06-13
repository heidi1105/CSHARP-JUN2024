# Notes on OneToMany

## 1. Project setup
- Add the 2 packages (MySQL & efCore design)
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
- For OneToMany, add the Foreign Key & the Navigation Properties
    ```cs
        public class Trip
        {
            public int HostId{get; set;} // Make sure it ends with Id
            public User? Host{get; set;}
        }
    ```
    - If there is more than 1 fk to that table, could add ```[ForeignKey(nameof(Host)), Column(Order = 0)] ``` above the foreign key (HostId) to specify the nav property
    ```cs
        public class User
        {
            // [InverseProperty(nameof(Trip.Host))]
            // The code above is not required if there is only 1 fk to that table
            public List<Trip> HostedTrips {get;} = new();
        }
    ```
    -  If there is more than 1 fk to that table, could add ```[InverseProperty(nameof(Trip.Host))] ``` above the HostedTrip to specify the nav property


    ```s
        dotnet ef migrations add FirstMigration           -- to add the Migration file
        dotnet ef database update                         -- To update the database

        If there is any error, add -v to see the error
    ```

## 3. CRUD
- From here, you should be familiar with the process of CRUD, please refer to previous notes/platform / your assignments