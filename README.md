## Project Documentation
- This is an app made using Clean Architecture, CQRS and MediatR.
- An web-based app for sharing ideas online.
- Web UI in Blazor or React is still work in progress, however we may consider the Api project and/or the built-in Swagger client to be the UI layer of the app.
- Unit and Integration tests availabe in the `tests/` directory as separate projects.
    - Unit test coverage is above or equal to 70% for the Core project - where the business logic resides.

## Environment Setup

- Install the Visual Studio 2022 Community IDE
    - Have the modules "ASP.NET and web development", ".NET desktop development", "Data storage and processing" installed.
    - Have .NET SDK and ASP.NET Core runtimes installed - version 6 or higher.
    - Have the dotnet-ef tool installed - version 7 or highter.

- Have MSSQLLocalDB and Microsoft SQL Server Management Studio Installed.

- Set your startup project be set to "Api (src\API\Api)"
    - Right-click on the Solution root from Solution Explorer and select "Configure Startup Projects..."".

- Start the app from your IDE, using the green triangle.


## Usage

Please use the swagger UI client for now.
In the future, using NSwag and Blazor or React the true UI layer would be built.

When you run the application, an console window will pop-up containing the information on which port the app is runing. 
For me that is `https://localhost:7082` - please consider the port and check if your is different.

Open the following page - `https://localhost:7082/swagger/index.html` and start interacting with the swagger UI.

## Licensing

MIT