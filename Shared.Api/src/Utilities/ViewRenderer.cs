using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;

namespace Nebula.Shared.Api.Utilities;

public class ViewRenderer
{
    private readonly IServiceProvider serviceProvider;
    private readonly ITempDataProvider tempDataProvider;
    private readonly IRazorViewEngine viewEngine;

    public ViewRenderer(IRazorViewEngine viewEngine, ITempDataProvider tempDataProvider, IServiceProvider serviceProvider)
    {
        this.viewEngine = viewEngine;
        this.tempDataProvider = tempDataProvider;
        this.serviceProvider = serviceProvider;
    }

    public async Task<string> RenderAsync<TModel>(string viewName, TModel model)
    {
        var httpContext = new DefaultHttpContext { RequestServices = serviceProvider };
        var actionContext = new ActionContext(httpContext, new RouteData(), new ActionDescriptor());
        var view = FindView(actionContext, viewName);

        await using var output = new StringWriter();

        var viewDataDictionary = new ViewDataDictionary<TModel>(new EmptyModelMetadataProvider(), new ModelStateDictionary())
        {
            Model = model
        };

        var tempDataDictionary = new TempDataDictionary(actionContext.HttpContext, tempDataProvider);
        var viewContext = new ViewContext(actionContext, view, viewDataDictionary, tempDataDictionary, output, new HtmlHelperOptions());

        await view.RenderAsync(viewContext);

        return output.ToString();
    }

    private IView FindView(ActionContext actionContext, string viewName)
    {
        var getViewResult = viewEngine.GetView(null, viewName, true);

        if (getViewResult.Success)
        {
            return getViewResult.View;
        }

        var findViewResult = viewEngine.FindView(actionContext, viewName, true);

        if (findViewResult.Success)
        {
            return findViewResult.View;
        }

        var searchedLocations = getViewResult.SearchedLocations.Concat(findViewResult.SearchedLocations);
        var errorMessage = string.Join(Environment.NewLine,
            new[] { $"Unable to find view '{viewName}'. The following locations were searched:" }.Concat(searchedLocations));

        throw new InvalidOperationException(errorMessage);
    }
}