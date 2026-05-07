# STAGE 1: Angular
FROM node:22-alpine AS node-build
WORKDIR /app/client
# Using your specific folder name: data-warehouse-web
COPY data-warehouse-web/package*.json ./
RUN npm install
COPY data-warehouse-web/ .
RUN npx ng build --configuration production

# STAGE 2: .NET
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS dotnet-build
WORKDIR /src

# Matches your Path: Root -> DataWarehouse -> DataWarehouse -> .csproj
COPY DataWarehouse/DataWarehouse/DataWarehouse.csproj ./DataWarehouse/DataWarehouse/
RUN dotnet restore "DataWarehouse/DataWarehouse/DataWarehouse.csproj"

# Copy the rest of the source
COPY . .

# Build the .NET DLL
WORKDIR "/src/DataWarehouse/DataWarehouse"
RUN dotnet publish "DataWarehouse.csproj" -c Release -o /publish

# STAGE 3: Final Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine
WORKDIR /app

# Install Node so server.js can run
RUN apk add --no-cache nodejs

# 1. Copy .NET files from Stage 2
COPY --from=dotnet-build /publish .

# 2. Copy Angular files from Stage 1 
# Based on your WORKDIR /app/client, the dist folder is at /app/client/dist/...
COPY --from=node-build /app/client/dist/data-warehouse-web/browser ./wwwroot

# 3. Copy the Node server script (Assuming it's in your Angular folder)
COPY --from=node-build /app/client/server.js .

# 4. Copy the Entrypoint script from your PROJECT ROOT (Windows side)
COPY entrypoint.sh .
RUN chmod +x ./entrypoint.sh

EXPOSE 8080

# This is the "Safety First" entrypoint for Alpine
ENTRYPOINT ["/bin/sh", "./entrypoint.sh"]