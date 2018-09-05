Write-Host "---==[ BEFORE BUILD" $env:project_name $env:APPVEYOR_BUILD_VERSION "SCRIPT ]==---"  
dotnet --version
Set-Location .\$env:project_name
dotnet restore
Write-Host ""

Write-Host "---==[ BUILD" $env:project_name $env:APPVEYOR_BUILD_VERSION "SCRIPT ]==---"  
dotnet build
Write-Host ""

Write-Host "---==[ AFTER BUILD" $env:project_name $env:APPVEYOR_BUILD_VERSION "SCRIPT ]==---"  
if($env:project_name -ilike "sol3.infrastructure*")  
{  
    dotnet pack --no-build /p:PackageVersion=$env:APPVEYOR_BUILD_VERSION
    nuget push .\bin\release\$env:project_name.$env:APPVEYOR_BUILD_VERSION.nupkg -ApiKey gnsob4ooc2th7pjtxx7yqflr -Source https://ci.appveyor.com/nuget/keithbarrows/api/v2/package
}
Set-Location ..