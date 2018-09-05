Write-Host "---==[ BEFORE BUILD" $env:project_name $env:APPVEYOR_BUILD_VERSION "SCRIPT ]==---"
dotnet --version
Set-Location .\$env:project_name
dotnet restore --verbosity normal

Write-Host "---==[ BUILD" $env:project_name $env:APPVEYOR_BUILD_VERSION "SCRIPT ]==---"
dotnet build --verbosity normal
Set-Location ..
