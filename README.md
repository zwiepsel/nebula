# Nebula

This is the monorepo of Nebula. This repo houses the backend and frontend code for Core and Client apps.

## Tech stack

This list only includes the major frameworks and libraries used.

-   [Entity Framework](https://docs.microsoft.com/en-us/ef/)
-   [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor)
-   [Syncfusion](https://www.syncfusion.com/blazor-components)
-   [Metronic](https://keenthemes.com/metronic/)

## Directory structure

    ├── Clients # Directory containing all client related code
    │ └── Client # Directory containing backend and frontend code specificly for that client
    │   ├── Apps #
    │   ├── Shared # Code shared among backend and frontend of a specific client
    │   └── Sites #Blazor code for the sites for a specific client
    ├── Core # Directory containing backend and frontend code for Nebula Core
    │ ├── Api # Core API backend code
    │ ├── Shared # Code shared among backend and frontend
    │ └── Web # Core frontend code
    ├── Shared # Code shared among Clients and Core
    ├── Shared.Api # Code shared among Clients and Core
    └── Shared.Clients # Code shared among Clients and Core

## Development

Commonly a day developing would look like this:

1. Start Core API optionally start client API (Backend)
2. Start Client app (Frontend)
3. Get to coding!

### Database

When developing for the first time you have to create a database call `Nebula`.

#### Upgrade/Setup Database

run `dotnet ef database update`

#### Create migration

run `dotnet ef migrations add {{name of migration}}`

to generate new migration script run `dotnet ef migrations script`

### APIs

#### Install

Make sure you have the right .Net SDK version, if not download it [here](https://dotnet.microsoft.com/download/dotnet).

#### Host file rewrites

Add the following rewrites to your host file:

```
127.0.0.1 core.nebula.local
127.0.0.1 apc.nebula.local
127.0.0.1 fcb.nebula.local
127.0.0.1 etb.nebula.local
127.0.0.1 my-fcb.nebula.local
```

#### Run

##### Start Core API

1. `cd Core/Api`
2. `dotnet run` or `dotnet run --watch`

##### Start Client API

1. `cd Clients/{{desired client}}`
2. `dotnet run` or `dotnet run --watch`

### Front End

#### Install

1. `cd Core/Web`
2. `npm install`

#### Run

1. `cd Core/Web`
2. `dotnet watch`

## Deployment

TO DO
