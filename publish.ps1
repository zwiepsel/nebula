Write-Host " >> Publishing Nebula.Core.Web"
cd "$PSScriptRoot\Core\Web"
& "scripts\publish.ps1"
cd $PSScriptRoot

Write-Host " >> Publishing Nebula.Core.Api"
cd "$PSScriptRoot\Core\Api"
& "scripts\publish.ps1"
cd $PSScriptRoot

Write-Host " >> Publishing Nebula.Clients.APC.Apps.RMP.Api"
cd "$PSScriptRoot\Clients\APC\Apps\RMP\Api"
& "scripts\publish.ps1"
cd $PSScriptRoot

Write-Host " >> Publishing Nebula.Clients.FCB.Apps.Portal.Api"
cd "$PSScriptRoot\Clients\FCB\Apps\Portal\Api"
& "scripts\publish.ps1"
cd $PSScriptRoot