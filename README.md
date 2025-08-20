# Star Fleet Manager

# Blazor Web App (.NET 8) with Authentication and EF Core

This project uses **ASP.NET Core Identity** for authentication/authorization and **Entity Framework Core** with a SQL Server database.

---

## Prerequisites

Before running the project, ensure you have:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio 2022 (17.8+)](https://visualstudio.microsoft.com/vs/) or [Visual Studio Code](https://code.visualstudio.com/)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (Express, Developer, or LocalDB)

---

## Setup Instructions

1. **Clone the Repository**
   - bash
   - git clone https://github.com/your-username/your-repo.git
   - cd your-repo
---
## Set Up Database Connection
Update the connection string in appsettings.json (or appsettings.Development.json):

```
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=YoruDB;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

Replace (localdb)\\MSSQLLocalDB with your SQL Server instance if different.

Change the database name if desired.

Apply Database Migrations
Run the following to create and seed the database:

`dotnet ef database update`


If you don’t have the EF Core tools installed:

`dotnet tool install --global dotnet-ef`


## Run the Application

`dotnet run`

## Authentication

This project uses ASP.NET Core Identity.

On first run, you can register a new account using the Register page.

Identity tables (users, roles, claims, etc.) are created automatically by EF Core migrations.

## Entity Framework Core

EF Core is used for data access.

Migrations are stored in the Migrations folder.

To add a new migration:

`dotnet ef migrations add MigrationName`
`dotnet ef database update`

Or with Package Manager Console:
`Add-Migration MigrationName`
`Update-Database`

## Project Notes

Styling: Bootstrap 5 is included and has been customized by yours truly. If you want, you can override the colors in wwwroot/css/app.css or via a SCSS pipeline if set up.

Authorization: Protect pages/components using the <AuthorizeView> component or [Authorize] attribute on pages.
- Example: A user must be logged in to seed the db or to add/edit/delete any StarShips.


## Troubleshooting

If the app fails to connect to SQL Server:

Verify SQL Server is running.

Check your connection string.

Ensure migrations are applied (dotnet ef database update).

If CSS/JS doesn’t update, clear your browser cache or restart the app.

## Assumptions made during development

- The data returned from the api is surprisingly inconsistent, especially in the "numeric" fields. Sometimes a field will come in as a string representing a numeric value, and sometimes it will come in as N/A or Unknown. For the most part, I was able to manage this inconsitency with some Try/Parsing in my View Model, but there are some instances where it felt like more work than it was worth to mitigate specific edge cases. This inconsistent data does have an effect on the column sorting in some cases, but in my opinion, since most of the inconsistencies are accounted for, a user can edit a Starship if they would like it to be sorted in line with the other ships.
- I heavily contemplated adding pagination to the table, but since it is searchable and sortable, I feel that a user is able to easily find what they are looking for without scrolling too much. If the table were expected to be much larger, say 50 or more items, I think it would be worth adding pagination.
- Rather than seeding the database automatically, I chose to give the user the option to seed the db with a button click. I just felt like it give the user the feeling of control.
