# Stage 1: Build Angular
FROM node:latest AS node-build
WORKDIR /app/client
COPY data-warehouse-web/package*.json ./
RUN npm install
COPY data-warehouse-web/ .
RUN npm run build --prod

# Stage 2: Build .NET
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS dotnet-build
WORKDIR /DataWarehouse/DataWarehouse
COPY *.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o /publish

# Stage 3: Final Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=dotnet-build /publish .
# Copy Angular files into the .NET wwwroot
COPY --from=node-build /app/client/dist/your-app-name/browser ./wwwroot
ENTRYPOINT ["dotnet", "YourApp.dll"]