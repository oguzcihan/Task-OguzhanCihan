
# How to run
1. Clone this repo
2. Open Project
3. Database migrations
4. Build and Run

Note: Since there is no valid database connectionstring at boot, IN-MEMORY will also be started by default. When you want to work with MSSQL, the update-database command should be run after the valid connection string is entered.

## Database migrations
```
PM> update-database
```

## Frameworks/libraries used:
* ASP.NET Core 6.0
* Entity Framework Core 6.0
* AutoMapper
* FluentValidation
* Autofac
* MSSQL Server
* InMemory
* JwtBearer
