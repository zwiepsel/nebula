// Theme.
const localStorageThemeKey = "theme";
const defaultTheme = "default-theme";
const darkTheme = "dark-theme";

window.GetCurrentTheme = function () {
    const currentTheme = localStorage.getItem(localStorageThemeKey);

    if (currentTheme === null) {
        localStorage.setItem(localStorageThemeKey, defaultTheme);
    }

    return localStorage.getItem(localStorageThemeKey);
}

window.SetTheme = function (theme) {
    const themeElement = document.getElementById("main-theme");
    const defaultThemeHref = document.getElementById(defaultTheme).getAttribute("href");
    const darkThemeHref = document.getElementById(darkTheme).getAttribute("href");

    if (theme === darkTheme) {
        localStorage.setItem(localStorageThemeKey, darkTheme);
        themeElement.setAttribute("href", darkThemeHref);
    } else {
        localStorage.setItem(localStorageThemeKey, defaultTheme);
        themeElement.setAttribute("href", defaultThemeHref);
    }
}

window.ChangeTheme = function () {
    const currentTheme = GetCurrentTheme();

    if (currentTheme === defaultTheme) {
        SetTheme(darkTheme);
    } else {
        SetTheme(defaultTheme);
    }
}

window.IsDarkTheme = function () {
    return GetCurrentTheme() === darkTheme;
}