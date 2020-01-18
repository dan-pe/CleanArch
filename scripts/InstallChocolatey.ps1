Write-Host "*** Installing Chocolatey ***"

$chocolateyVersion = powershell choco -v
if(-not($chocolateyVersion)){
    Set-ExecutionPolicy Bypass -Scope Process -Force; iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))
}
else{
    Write-Output "Chocolatey is already installed version: ($chocolateyVersion)."
}
