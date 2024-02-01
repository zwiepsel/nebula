using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Nebula.Shared.Clients.Settings;
using Nebula.Shared.Clients.Startup;
using Nebula.Shared.Models.Site;
using Nebula.Shared.Utilities;

namespace Nebula.Core.Web.Extensions;

public static class WebAssemblyHostBuilderExtensions
{
    public static async Task ConfigureSites(this WebAssemblyHostBuilder webAssemblyHostBuilder, CoreApiSettings apiSettings)
    {
        // Retrieve the current site.
        var appBaseUri = new Uri(webAssemblyHostBuilder.HostEnvironment.BaseAddress);
        var response = await new HttpClient().GetAsync($"{apiSettings.Uri}/site/{appBaseUri.Host}");

        // Site found, continue configuring the site and it's apps.
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStreamAsync();
            var site = await JsonSerializer.DeserializeAsync<SiteViewModel>(content);

            if (!site.Core)
            {
                // Configure the site.
                ((ISiteStartup)Activator.CreateInstance(site.GetStartupType())!).Configure(webAssemblyHostBuilder);

                // Loop through the site's apps and configure them.
                foreach (var app in site.Apps)
                    ((IAppStartup)Activator.CreateInstance(app.GetStartupType())!).Configure(webAssemblyHostBuilder);
            }
        }
    }
}