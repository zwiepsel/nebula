dotnet ef database drop -f
Remove-Item -Path .\Migrations\*
dotnet ef migrations add InitialCreate
dotnet ef database update