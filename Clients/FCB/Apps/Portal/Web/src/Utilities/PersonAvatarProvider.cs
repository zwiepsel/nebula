using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Nebula.Clients.FCB.Shared.Models.Person;
using Nebula.Shared.Extensions;

namespace Nebula.Clients.FCB.Apps.Portal.Web.Utilities;

public static class PersonAvatarProvider
{
    private static Dictionary<int, MarkupString> renderedAvatars = new();

    public static MarkupString GetAvatar(PersonViewModel? personViewModel)
    {
        if (personViewModel != null)
        {
            if (renderedAvatars.ContainsKey(personViewModel.Id))
            {
                return renderedAvatars[personViewModel.Id];
            }

            var height = "h-150px";
            var gender = personViewModel.Gender.ToString().ToLower();
            var number = new Random().Next(1, 4);

            if (personViewModel.DateOfBirth.ToAge() < 18)
            {
                height = "h-100px";
            }

            var avatar = new MarkupString($"<img src=\"/dist/img/avatars/{gender}{number}.svg\" class=\"align-self-end {height}\">");

            renderedAvatars.Add(personViewModel.Id, avatar);

            return renderedAvatars[personViewModel.Id];
        }

        return new MarkupString();

    }
}