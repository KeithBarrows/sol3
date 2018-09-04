#########################################################################################
Write-Host "---==[ BEFORE BUILD " $env:project_name " SCRIPT ]==---"  
dotnet --version
Set-Location .\$env:project_name
Get-ChildItem
dotnet restore ###$env:project_name/$env:project_name.csproj
Write-Host "---==[ DONE ]==---"
Write-Host ""
#########################################################################################
Write-Host "---==[ BUILD " $env:project_name " SCRIPT ]==---"  
dotnet build ###$env:project_name/$env:project_name.csproj -c Release
Write-Host "---==[ DONE ]==---"
#########################################################################################
Write-Host "---==[ AFTER BUILD " $env:project_name " SCRIPT ]==---"  
if($env:project_name -ieq "sol3.infrastructure")  
{  
    Write-Host "HERE IS WHERE WE PACK AND PUBLISH THE " $env:project_name " NUGET"  
}
if($env:project_name -ieq "sol3.infrastructure.iot")  
{  
    Write-Host "HERE IS WHERE WE PACK AND PUBLISH THE " $env:project_name " NUGET"  
}
Write-Host "---==[ DONE ]==---"
Set-Location ..
#########################################################################################
