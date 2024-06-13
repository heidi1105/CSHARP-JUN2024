# Welcome to the C# stack with Heidi

## Schedule 
<table>
<thead>
    <th></th>
    <th></th>
    <th> Category </th>
    <th> Topic </th>
    <th> Remarks</th>
</thead>
    <tbody>
    <tr>
        <td>W1D1 </td>
        <td>1</td>
        <td>C# Fundamentals</td>
        <td>Fundamentals </td>
        <td><a href="./01-fundamentals/FundamentalDemo/">Code </a></td>
    </tr>
    <tr>
        <td>W1D2 </td>
        <td>2</td>
        <td>C# OOP</td>
        <td>Class, Properties, Inheritance, Interfaces 
        </td>
        <td> <a href="./02-oop/OOPDemo/">Code </a></td>
    <tr>
        <td>W1D3 </td>
        <td>3</td>
        <td> .NET web</td>
        <td> Routing, Razor, Forms</td>
        <td><a href="./03-mvc/WebDemo/">Code </a></td>
    </tr>
        <tr>
        <td>W1D4 </td>
        <td></td>
        <td>.NET MVC</td>
        <td>Models, ViewModels & Forms, Validations</td>
        <td><a href="./03-mvc/MVCDemo/">Code </a></td>
    </tr>
    <tr>
        <td>W1D5 </td>
        <td></td>
        <td></td>
        <td>Sessions </td>
        <td><a href="./03-mvc/MVCDemo/">Code </a></td>
    </tr>
    <tr>
        <td>W2D1 </td>
        <td>4</td>
        <td>ORM - Query</td>
        <td>Linq (Language Integrated Query)</td>
        <td><a href="./04-orm/LinqDemo/Program.cs">Code </a></td>
    </tr>
    <tr>
        <td>W2D2 </td>
        <td></td>
        <td>ORM - CRUD </td>
        <td>CRUD with MySQL using Linq</td>
        <td><a href="./04-orm/CRUD.md">Notes </a>
        </td>
    </tr>
    <tr>
        <td>W2D3 </td>
        <td></td>
        <td></td>
        <td>Partials, LogReg </td>
        <td><a href="./04-orm/LogReg.md">Notes </a></td>
    </tr>
    <tr>
        <td> W2D4 </td>
        <td></td>
        <td>ORM - Relationships</td>
        <td>One-to-many, Linq to join tables</td>
        <td><a href="./05-belt-review/OneToMany.md">Notes </a></td>
    </tr>
    <tr>
        <td> W2D5 </td>
        <td></td>
        <td></td>
        <td>Many-to-many</td>
        <td></td>
    </tr>
    <tr>
        <td> W3D1 </td>
        <td>5 </td>
        <td>Belt Prep</td>
        <td>Exam rubric, Project with logreg, 1:n, m:n</td>
        <td> </td>
    </tr>
    </tbody>
</table>

## Creating snippets
1. Copy the code to create snippets - [Snippet-generator](https://snippet-generator.app/?description=&tabtrigger=&snippet=&mode=vscode)
2. VS Code --> View --> Command Palette --> Snippet: Configure User Snippets --> FileExtension.json
3. Update the title & prefix to use the snippet


## Dotnet Command cheatsheet
- To cd into the folder
  - Type ```cd ```, then drag the folder to the terminal
  - ```cd FolderName ``` (Make sure you are at the right directory)
- To run the application
  - ``` dotnet watch run ``` Will relaunch if there is update
  - ``` dotnet run ``` Will run it once
- To stop the application
  - Control/Ctrl + C 
- Console application:
  - ``` dotnet new console ``` if you are inside the folder
  - ``` dotnet new console -o ProjectName ``` To also create the project folder
- Web Application without MVC structure
  - ``` dotnet new web --no-https ``` (inside the folder)
  - ``` dotnet new web --no-https -o ProjectName ``` (To create the folder)
- Web Application with MVC structure
  - ``` dotnet new mvc --no-https ``` (inside the folder)
  - ``` dotnet new mvc --no-https -o ProjectName ``` (To create the folder)
- Adding DB migrations
  - ``` dotnet ef migrations add MigrationName ``` (Migration name cannot be repeated, could add -v to enable verbose to see the details if it fails)
  - ```dotnet ef database update``` (To update DB)
  - ```rm -rf Migrations ``` To remove all the migrations