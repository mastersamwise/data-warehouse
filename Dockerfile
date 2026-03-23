# STAGE 1: Angular (Same as before)
FROM node:22-alpine AS node-build
WORKDIR /app/client
COPY data-warehouse-web/package*.json ./
RUN npm install
COPY data-warehouse-web/ .
RUN npx ng build --configuration production

# STAGE 2: .NET (Updated for double-folder structure)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS dotnet-build
WORKDIR /src

# Copy the csproj from the double-nested folder
# Path: Root -> DataWarehouse -> DataWarehouse -> .csproj
COPY DataWarehouse/DataWarehouse/DataWarehouse.csproj ./DataWarehouse/DataWarehouse/
RUN dotnet restore "DataWarehouse/DataWarehouse/DataWarehouse.csproj"

# Copy everything else
COPY . .

# Move into the inner folder where the code actually lives
WORKDIR "/src/DataWarehouse/DataWarehouse"
RUN dotnet publish "DataWarehouse.csproj" -c Release -o /publish

# STAGE 3: Final Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=dotnet-build /publish .

# IMPORTANT: Double check this path in your local 'dist' folder!
COPY --from=node-build /app/client/dist/data-warehouse-web/browser ./wwwroot

EXPOSE 8080
#ENTRYPOINT ["dotnet", "DataWarehouse.dll"]
ENTRYPOINT ["./entrypoint.sh"]