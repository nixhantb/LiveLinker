#!/bin/bash

# Exit on any error
set -e

# Define migration name (optional, defaults to "InitialMigration")
MIGRATION_NAME=${1:-"InitialMigration"}

echo "Starting migration and database update process..."

# Create migration
dotnet ef migrations add "$MIGRATION_NAME"

# Update database
dotnet ef database update

echo "Migration '$MIGRATION_NAME' created and database updated successfully."
