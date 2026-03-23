# data-warehouse

## Nik

1. `cd data-warehouse-web`
2. `ng serve`
3. Open http://localhost:4200/
3. `cd DataWarehouse/DataWarehouse`
4. `dotnet build && dotnet run`

## Dockerize
https://gemini.google.com/app/7a270bba55a136d4
Github Synology Docker token: `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`
Github Synology Docker token: new `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`

docker build --platform linux/amd64 -t ghcr.io/mastersamwise/data-warehouse:latest .
Login: docker login ghcr.io -u mastersamwise

Build: docker build -t ghcr.io/mastersamwise/data-warehouse:latest .

Push: docker push ghcr.io/mastersamwise/data-warehouse:latest