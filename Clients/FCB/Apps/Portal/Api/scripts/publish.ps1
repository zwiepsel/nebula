$publishPath = $ENV:UserProfile + "\Publish\Nebula\Nebula.Clients.FCB.Apps.Portal.Api"

If (Test-Path $publishPath)
{
    Remove-Item $publishPath\* -Recurse -Force
}

dotnet publish -c Release -o $publishPath

If (Test-Path $publishPath\web.config)
{
    Remove-Item $publishPath\web.config -Force
}

If (Test-Path $publishPath\wwwroot)
{
    Remove-Item $publishPath\wwwroot -Recurse -Force
}