Write-Host "---==[ BEFORE BUILD Sol3.Infrastructure.IoT 0.0.47 SCRIPT ]==---"
Set-Location E:\Apps\sol3\Sol3.Infrastructure.IoT
dotnet --version
dotnet restore --verbosity normal

Write-Host "---==[ BUILD Sol3.Infrastructure.IoT 0.0.47 SCRIPT ]==---"
dotnet build Sol3.Infrastructure.IoT.csproj --verbosity normal

Write-Host "---==[ AFTER BUILD Sol3.Infrastructure.IoT 0.0.47 SCRIPT ]==---"
dotnet pack --no-build /p:PackageVersion=0.0.47 --verbosity normal
Set-Location E:\Apps\sol3\Sol3.Infrastructure.IoT\bin\Debug
E:\PublishTools\nuget.exe push -Source "VSTS" -ApiKey terran Sol3.Infrastructure.IoT.0.0.47.nupkg 
