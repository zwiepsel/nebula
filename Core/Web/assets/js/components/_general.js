// User menu.
window.UserMenuShow = function () {
    const userMenu = document.getElementById('user-menu');
    userMenu.classList.add("show");

    // Close user menu.
    window.addEventListener('mouseup', function (event) {
        if (event.target !== userMenu && event.target.parentNode !== userMenu) {
            userMenu.classList.remove("show");
        }
    });
}

// Sidebar.
window.ExpandSidebar = function () {
    const body = document.getElementsByTagName('body')[0];
    body.removeAttribute('data-kt-aside-minimize');
    document.getElementById("toggle-icon").classList.remove("rotate-180");
}

// Toggle aside.
window.ToggleAside = function () {
    const aside = document.getElementById('aside-toggle');
    const body = document.getElementsByTagName('body')[0];

    if (aside.className === "btn btn-icon w-auto px-0 btn-active-color-primary aside-toggle active") {
        aside.className = "btn btn-icon w-auto px-0 btn-active-color-primary aside-toggle"
        document.getElementById("toggle-icon").classList.remove("rotate-180");
        body.removeAttribute('data-kt-aside-minimize');
    } else {
        aside.className = "btn btn-icon w-auto px-0 btn-active-color-primary aside-toggle active"
        document.getElementById("toggle-icon").classList.add("rotate-180");
        body.setAttribute('data-kt-aside-minimize', 'on');
    }
}

// Off canvas.
window.OffCanvasShow = function (id, overlay = false) {
    document.getElementById(id).classList.add("drawer-on");

    if (overlay) {
        document.getElementById(id + "-overlay").classList.add("drawer-overlay");
    }
}

window.OffCanvasHide = function (id, overlay = false) {
    document.getElementById(id).classList.remove("drawer-on");

    if (overlay) {
        document.getElementById(id + "-overlay").classList.remove("drawer-overlay");
    }
}

// Scrolling.
window.ScrollIntoId = function (id, behavior = "smooth") {
    document.getElementById(id).scrollIntoView({behavior: behavior})
}

// Blazor error UI.
window.CloseBlazorErrorUi = function () {
    document.getElementById("blazor-error-ui").style.display = "none";
}

// Reload page.
window.ReloadPage = function () {
    window.location.reload(false);

    return false;
}

// Download file.
window.DownloadFile = function (fileName, fileContents) {
    const link = document.createElement('a');
    link.download = fileName;
    link.href = "data:application/octet-stream;base64," + fileContents;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}

// Checks if element by ID exists.
window.ElementByIdExists = function (id) {
    const element = document.getElementById(id);

    return typeof (element) != 'undefined' && element != null;
}

// Get element offset height by ID.
window.GetElementOffsetHeightById = function (id) {
    return document.getElementById(id).offsetHeight;
}

// Set element height by ID.
window.SetElementHeightById = function (id, height) {
    document.getElementById(id).style.height = height + "px";
}
