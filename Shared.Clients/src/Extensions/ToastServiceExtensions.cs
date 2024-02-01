using Blazored.Toast.Services;

namespace Nebula.Shared.Clients.Extensions;

public static class ToastServiceExtensions
{
    public static void ShowCreated(this IToastService toastService, string name)
    {
        toastService.ShowSuccess($"{name} created.");
    }

    public static void ShowUpdated(this IToastService toastService, string name)
    {
        toastService.ShowSuccess($"{name} updated.");
    }

    public static void ShowAdded(this IToastService toastService, string name)
    {
        toastService.ShowSuccess($"{name} added.");
    }

    public static void ShowLinked(this IToastService toastService, string name)
    {
        toastService.ShowSuccess($"{name} linked.");
    }

    public static void ShowUnlinked(this IToastService toastService, string name)
    {
        toastService.ShowSuccess($"{name} unlinked.");
    }

    public static void ShowRemoved(this IToastService toastService, string name)
    {
        toastService.ShowSuccess($"{name} removed.");
    }

    public static void ShowUnexpectedError(this IToastService toastService)
    {
        toastService.ShowError("An unexpected has error occurred.");
    }

    public static void ShowNotFound(this IToastService toastService, string name)
    {
        toastService.ShowError($"{name} could not be found.");
    }
}