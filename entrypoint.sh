#!/bin/bash
echo "--- STARTING DATA WAREHOUSE SERVICES ---"

# start Node in background
cd /data-warehouse/data-warehouse-web
node server.js &

# start .net backend
cd /data-warehouse/DataWarehouse/DataWarehouse/
exec dotnet DataWarehouse.dll