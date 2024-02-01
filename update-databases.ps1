$projects = [ordered]@{ 
    "Nebula.Core.Api" = "Core\Api"
    "Nebula.Clients.APC.Apps.RMP.Api" = "Clients\APC\Apps\RMP\Api"
    "Nebula.Clients.FCB.Apps.Portal.Api" = "Clients\FCB\Apps\Portal\Api"
    "Nebula.Clients.ETB.Apps.Portal.Api" = "Clients\ETB\Apps\Portal\Api"
}

foreach ($project in $projects.GetEnumerator()) {
    Write-Host " >> Updating $($project.Name) database"
    Set-Location "$PSScriptRoot\$($project.Value)"
    & dotnet ef database update
    Set-Location $PSScriptRoot
}