# FreelancerCRM-ASP.NET-6.0
Backend for project of web development subject

## Setup
1. Install MS SQL
2. Open project folder and open the Presentation folder
3. Change database connection string in appsettings.json to your connection string from SSMS
3. If you don't have a EF Core [install it](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)
4. Open terminal and run command `dotnet ef database update --project .\Persistence\ --startup-project .\Presentation\`
