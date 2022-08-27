## Update .NET API to use MySQL
dotnet add package Pomelo.EntityFrameworkCore.MySql

Open the appsettings.json file and add the entry "ConnectionStrings" with a child entry for the MySQL connection string (e.g. "WebApiDatabase"), the connection string should be in the format "server=[DB SERVER URL]; database=[DB NAME]; user=[USERNAME]; password=[PASSWORD]".

Update Data Context to Use MySQL

## Install dotnet ef tools
The .NET Entity Framework Core tools (dotnet ef) are used to generate EF Core migrations, to install the EF Core tools globally run --> 'dotnet tool install -g dotnet-ef', or to update run --> 'dotnet tool update -g dotnet-ef'.

## Add EF Core Design package from NuGet
dotnet add package Microsoft.EntityFrameworkCore.Design

Generate EF Core migrations Generate new EF Core migration files by running the command ---> 'dotnet ef migrations add InitialCreate' from the project root folder (where the WebApi.csproj file is located), these migrations will create the database and tables for the .NET Core API. To undo this action, use --> 'ef migrations remove'

## Execute EF Core migrations
Run the command --> 'dotnet ef database update' from the project root folder to execute the EF Core migrations and create the database and tables in MySQL.

Check MySQL and you should now see your database with the tables Users and __EFMigrationsHistory.

Restart .NET 6.0 CRUD API Stop and restart the API with the command dotnet run from the project root folder, you should see the message Now listening on: http://localhost:4000 and the API should now be connected to MySQL.