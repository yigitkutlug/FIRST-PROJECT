# FirstProjectApi

RESTful API using ASP.NET Core + Entity Framework Core + SQL Server (LocalDB).

## Requirements Completed

- Naming conventions are applied (`BooksController`, `Book`, `AppDbContext`)
- At least one controller exists (`BooksController`)
- Entity Framework Core implementation exists (`AppDbContext` + SQL Server provider)
- Postman usage is included (`Postman/FirstProjectApi.postman_collection.json`)

## Endpoints

- `GET /api/books`
- `GET /api/books/{id}`
- `POST /api/books`
- `PUT /api/books/{id}`
- `DELETE /api/books/{id}`

## Run

```powershell
$env:DOTNET_CLI_HOME='c:\Users\YIGIT\Desktop\Projeler\1.Proje\.dotnet'
dotnet restore
dotnet run
```

## Postman

1. Import `Postman/FirstProjectApi.postman_collection.json`.
2. Set `baseUrl` variable to your local API address from terminal output.
3. Run requests in order: `Get All Books`, `Create Book`, `Update Book`, `Delete Book`.

## GitHub

Push all files to your own GitHub account as requested by the assignment.