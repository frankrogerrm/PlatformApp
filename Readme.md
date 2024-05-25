# Platform App

Frank Ramos

## Tools

1. Net Core 8.0
2. MSSQL Server
3. Entity Framework
4. LinQ
5. React
6. Azure
7. VSCode
8. Visual Studio

## Local

1. Restore the db backup contained in the db folder
2. In the project PlatformApp.Api Change the appsettings.json to use the correct connection string to the db
3. (Optional) you can run the update-database to create and  populate the db manually
4. In the React project (platform-app-web) find the file APICalls.js and modify the tag baseURL according to the url deployed in PlatformApp.api

## Remote

1. You can find the react application running at https://ephemeral-empanada-9e77d7.netlify.app/
2. You can find the api running at https://platform-app-service-2024.azurewebsites.net/swagger/index.html

Thanks