Write-Host "*** Running DevSetup ***"

Get-ChildItem "C:\Repositories\cleanarch\scripts\*.ps1" | 
ForEach-Object {
  $filename = $_.FullName
  & $filename
}