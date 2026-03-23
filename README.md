# data-warehouse

## Nik

1. `cd data-warehouse-web`
2. `ng serve`
3. Open http://localhost:4200/
3. `cd DataWarehouse/DataWarehouse`
4. `dotnet build && dotnet run`

## Dockerize
https://gemini.google.com/app/7a270bba55a136d4
github tokens located at C:\Users\Nik\Git_Repos\github_tokens.txt

docker build --platform linux/amd64 -t ghcr.io/mastersamwise/data-warehouse:latest .
Login: docker login ghcr.io -u mastersamwise

Build: docker build -t ghcr.io/mastersamwise/data-warehouse:latest .

Push: docker push ghcr.io/mastersamwise/data-warehouse:latest