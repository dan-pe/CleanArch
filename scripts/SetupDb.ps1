Write-Host "*** Installing Db ***"

Write-Host "  -> Installing EF"
dotnet tool install --global dotnet-ef --version 3.1.0

Write-Host "  -> Running Migrations"

Invoke-Expression "dotnet ef database update --project 'CleanArch.Notes.Api'"
Invoke-Expression "dotnet ef database update --project 'CleanArch.Stash.Api'"