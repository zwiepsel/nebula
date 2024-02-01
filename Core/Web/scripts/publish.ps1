$publishPath = $ENV:UserProfile + "\Publish\Nebula\Nebula.Core.Web"

If (Test-Path $publishPath)
{
    Remove-Item $publishPath\* -Recurse -Force
}

npm run production
dotnet publish -c Release -o $publishPath

If (Test-Path $publishPath\web.config)
{
    Remove-Item $publishPath\web.config -Force
}

If (Test-Path $publishPath\wwwroot\_content\Syncfusion.Blazor.Themes)
{
    Remove-Item $publishPath\wwwroot\_content\Syncfusion.Blazor.Themes -Recurse -Force
}