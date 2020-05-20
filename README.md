## README
### Configuration
- Use the appsettings.json CsvFilePath key to specify the location of the sample csv file
- Use the appsettings.json UseSql key to determine, wether to use MSSQL or not (it is false by default)

#### UseSql = true
In order to use MSSQL, perform the following steps

1. Create a local database with name PersonManagementDB

2. Navigate to the folder PersonManagement.Api and run:

    `dotnet ef database update --context PersonManagementDbContext`