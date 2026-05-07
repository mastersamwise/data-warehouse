#!/bin/sh
echo "--- STARTING DATA WAREHOUSE SERVICES ---"

# Start the Node server in the background
node /app/server.js &

# Start the .NET app in the foreground
exec dotnet /app/DataWarehouse.dll