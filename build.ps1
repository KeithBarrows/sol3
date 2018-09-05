#########################################################################################
Write-Host "---==[ BEFORE BUILD" $env:project_name "SCRIPT ]==---"  
dotnet --version
Set-Location .\$env:project_name
Get-ChildItem
dotnet restore ###$env:project_name/$env:project_name.csproj
Write-Host ""
#########################################################################################
Write-Host "---==[ BUILD" $env:project_name "SCRIPT ]==---"  
dotnet build ###$env:project_name/$env:project_name.csproj -c Release
Write-Host ""
#########################################################################################
Write-Host "---==[ AFTER BUILD" $env:project_name "SCRIPT ]==---"  
if($env:project_name -ilike "sol3.infrastructure*")  
{  
    dotnet pack --no-build
    Get-ChildItem
    Write-Host "nuget push $env:project_name.nuspec -ApiKey gnsob4ooc2th7pjtxx7yqflr -Source https://ci.appveyor.com/nuget/keithbarrows/api/v2/package"
}
Set-Location ..
#########################################################################################