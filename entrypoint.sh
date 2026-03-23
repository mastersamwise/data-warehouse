#!/bin/bash
node server.js &  # Start Node in the background
dotnet DataWarehouse.dll # Start .NET in the foreground