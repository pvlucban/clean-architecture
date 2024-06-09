Application Data
To add migration
dotnet ef migrations add InitialCreate -p ./Infrastructure/Clean-Architecture.Infrastructure.Data -s ./Presentation/Clean-Architecture.WebApi -c ApplicationDBContext

To Remove
dotnet ef migrations remove -p ./Infrastructure/Clean-Architecture.Infrastructure.Data -s ./Presentation/Clean-Architecture.WebApi -c ApplicationDBContext

To update database
dotnet ef database update -p ./Infrastructure/Clean-Architecture.Infrastructure.Data -s ./Presentation/Clean-Architecture.WebApi -c ApplicationDBContext

Identity Store
To add migration
dotnet ef migrations add InitialCreate -p ./Infrastructure/Clean-Architecture.Infrastructure.Identity -s ./Presentation/Clean-Architecture.WebApi -c UserDBContext

To Remove
dotnet ef migrations remove -p ./Infrastructure/Clean-Architecture.Infrastructure.Identity -s ./Presentation/Clean-Architecture.WebApi -c UserDBContext

To update database
dotnet ef database update -p ./Infrastructure/Clean-Architecture.Infrastructure.Identity -s ./Presentation/Clean-Architecture.WebApi -c UserDBContext
