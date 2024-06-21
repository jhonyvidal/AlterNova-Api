## connection string

update `appsettings.json`  in `ConnectionStrings.DefaultConnection` Make sure that any required environment variables or configuration settings are properly set before running the API.

## note

Ensure that your database connection string is correctly configured file for Entity Framework Core migrations to work properly.

## Doctors and Types

To insert mock data to doctor and type entities use `Query.sql` file.

## Add Migration

Navigate to API Project
Use `cd AlertnovaData` for get data services. 
Run `dotnet ef database update` for a install dependencies. 

## Running the API

Navigate to API Project

## Build the Project

Run `dotnet build` This will compile your project and generate the necessary binaries. 

## Run the API

Run `dotnet run` This command will launch your API application. Once it's running, you can access it through the specified endpoint (e.g., https://localhost:5000).



 
