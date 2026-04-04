#!/bin/sh
node /app/server.js &  # Start Node in the background
dotnet app/DataWarehouse.dll # Start .NET in the foreground