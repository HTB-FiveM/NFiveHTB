# NFiveHTB

NFiveHTB project is a re-work by Harry The Bastard of the NFive.io plugin system for FiveM

To edit it, open `NFiveHtb.sln` in Visual Studio.

To build it, run `build.cmd`. To run it, run the following commands to make a symbolic link in your server data directory:

```dos
cd /d [PATH TO THIS RESOURCE]
mklink /d X:\cfx-server-data\resources\[local]\NFiveHtb dist
```

Afterwards, you can use `ensure NFiveHtb` in your server.cfg or server console to start the resource.


# Database Migrations
Need to install dotnet sdk tooling:
dotnet tool install --global dotnet-ef

Add migrations with:
dotnet ef migrations --verbose --project .\Server\NFiveHtb.Server.csproj --startup-project .\Migrations\Migrations.csproj add <Migration Name>

