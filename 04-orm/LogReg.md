# Notes on LogReg

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
- Add the session in Program.cs
  ```cs
    // Add these 2 lines before builder.Build() 
    builder.Services.AddHttpContextAccessor();  
    builder.Services.AddSession();  


    // Add the following line after creating the app
    app.UseSession();   
  ```


## 2. User Model & DB
- Add Model & Add the DbSet on Context file as well
  ```cs
    // Add namespace & using packages
    public class User
    {
       // Please refer to the platform and add the validation required from the wireframe

       // For ConfirmPassword, make sure it is [NotMapped] as we don't want to store it on SQL
    }
  ```
- Add custom validation for UniqueEmail (Follow the platform) 
- Add migration & update database. Check your db structure before moving on!

    ```s
        dotnet ef migrations add FirstMigration           -- to add the Migration file
        dotnet ef database update                         -- To update the database

        If there is any error, add -v to see the error
    ```
- Add LoginUser but make sure the Email & Password is not the same name as the User. Example below:
  ```cs
    [Required]
    public string LoginEmail { get; set;} 
    // Cannot be the same name as the Register form
  ```

## 3. Partials & Layout
- Follow Multiple Models Single View on the platform (But using LoginUser & User)
- Create Index.cshtml and the partials for _LoginForm & _RegisterForm
- Make sure the form looks good and using tag helper (asp-for & asp-validation-for)

## 4. Register Process
- Process the User by adding that in the parameter
- Test your validation
- Hashing the password before Save (Follow the platform)
- Add UserId in the session if it is successfully registered

## 5. Login Process
- Process the Login by adding that in the parameter
- Follow the platform for the code details but think about the process when you code along
    ```cs
        // ------ Pseudocode for the login process -----
        // 1. get the dbuser by email 
        // 2.1 If dbUser is null, add Err & redirect
        // 2.2 Use the dbUser and check with the form password
        // 3. If the result from VerifyHashedPassword is 0, the verification fails (Wrong password), add error and return
        // 4. If it could reach this line, all are validated. Store UserId in the session
    ```

## 6. Logout & Route Protection
- Create the Action (In Controller) to clear session and redirect
- Create the form with button to go into the above Action
- Create the custom validation for SessionCheckAttribute 
  - Could follow the platform but make sure the Action & Controller name is correct
  - And make sure the session key you are getting is the same as how you set in Login process/ Register process
- Add the SessionCheck annotation on the route or controller you want to have route protection