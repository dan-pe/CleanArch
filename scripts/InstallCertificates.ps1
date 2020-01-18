Write-Host "*** Installing Certificates ***"

Write-Host " -> Installing Dev-Certs"

Invoke-Expression "dotnet dev-certs https --clean"
Invoke-Expression "dotnet dev-certs https -t"