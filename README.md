# Rhea

## About

Rhea repository contain the coding challenge application done in C# and .Net.

##Installation

- Make sure to have .Net SDK 6.0 installed in your machine https://dotnet.microsoft.com/en-us/download/dotnet/6.0
- A connection to a SQL database
- Clone the project
- Expand the file project "Rhea.DAL" and delete the folder "Migrations"
- In the "Rhea" project, got to the appsettings.json, expand it and open the appsettings.Development.json, you will find the "ConnectionStrings" property, them update the value of the property "RheaDbContext" to make reference to a connection string for your Database location. This tool can help to generate your connection string if you don't have one https://www.aireforge.com/tools/sql-server-connection-string-generator

```
 "ConnectionStrings": {
      "RheaDbContext": "Data Source=JEAN;Database=RheaDB;Integrated Security=sspi;Connection Timeout=30;"
    }
```

- Open you Package Manager Console, and run the command:

```
  add-migration -Context RheaDbContext "First migration"
```
- When the console finish creating the migration file, in your Package Manager Console run the command:
```
update-migration -Context RheaDbContext
```
- This will create the database and will allow us to start using the API

## API

# Important!

Before starting to use the API, we need to fill the tables that hold the type and status Ids, to do this follow these steps:

- Run the application, this will automatically open the Swagger
- In the swagger, go to the ComboBox controller and expand the POST HTTP verb with the url "FillComboxTables"
- Execute this endpoint and this will automatically fill the tables required to run the application

## Create a User

When creating an user, the user will be a Person, or a Company. Use the User Controller and expand the endpoint CreateUser.

Create Person:
- UserType = 1
- Email = "test@outlook.com
- FirstName "Alex"
- LastName "Rodriguez"
- DateOfBirth 5/5/1990

Execute and this will create the user.

Make a reservation

Use the controller Event and the endpoint CreateEvent

IdUser: {Your user id}
IdEventType: The id of the type of the event
Name: Nombre del evento
Startime: Date and time of the start of the event 5/5/2023 8:00 AM
Startime: Date and time of the end of the event 5/5/2023 11:00 AM
FurnituresIds: The id of the furnitures that are being rented, this optional
