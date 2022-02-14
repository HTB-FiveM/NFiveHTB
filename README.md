# NFiveHTB

NFiveHTB project is a re-work by Harry The Bastard of the NFive.io plugin system for FiveM

To edit it, open `NFive.sln` in Visual Studio.

To build it, run `build.cmd`.
To add as a FiveM resource, run the following commands to make a symbolic link in your server data directory:


In a command prompt (might need to be run the cmd.exe as Administrator):
```
mklink /d [PATH TO YOUR RESOURCES FOLDER]\NFiveHtb [PATH TO THE PARENT FOLDER OF WHERE THE BUILD.CMD WAS RUN FROM]\dist
```
Check that a link under resources folder has been created and you can open it in Windows Explorer or CD to it from command prompt

Afterwards, you can use `ensure NFiveHtb` in your server.cfg or server console to start the resource.


# Database Migrations - For Development when you modify db entities, not needed when you're just installing the base framework
Need to install dotnet sdk tooling:
dotnet tool install --global dotnet-ef

Add migrations with:
dotnet ef migrations --verbose --project .\Server\NFive.Server.csproj --startup-project .\Migrations\Migrations.csproj add <Migration Name>

