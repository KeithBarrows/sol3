########################################################################################
Write-Host "---==[ BEFORE BUILD" $env:project_name "SCRIPT ]==---"  
Write-Host "Build Number:" $env:APPVEYOR_BUILD_NUMBER
Write-Host "Build Version:" $env:APPVEYOR_BUILD_VERSION
dotnet --version
Set-Location .\$env:project_name
Get-ChildItem
dotnet restore ###$env:project_name/$env:project_name.csproj
Write-Host ""
########################################################################################
Write-Host "---==[ BUILD" $env:project_name "SCRIPT ]==---"  
dotnet build ###$env:project_name/$env:project_name.csproj -c Release
Write-Host ""
########################################################################################
Write-Host "---==[ AFTER BUILD" $env:project_name "SCRIPT ]==---"  
if($env:project_name -ilike "sol3.infrastructure*")  
{  
    dotnet pack --no-build /p:PackageVersion=$env:APPVEYOR_BUILD_VERSION
    Set-Location .\bin\release
    nuget push $env:project_name.$env:APPVEYOR_BUILD_VERSION.nupkg -ApiKey gnsob4ooc2th7pjtxx7yqflr -Source https://ci.appveyor.com/nuget/keithbarrows/api/v2/package
    Set-Location ../..
}
Set-Location ..
########################################################################################