@echo off
pushd Client
dotnet publish -c Release
popd

pushd Server
dotnet publish -c Release
popd

rmdir /s /q dist
mkdir dist

copy /y fxmanifest.lua dist
copy /y index.html dist
xcopy /y /e NFive.Client\bin\Release\net471\publish dist\Client\
xcopy /y /e NFive.Server\bin\Release\netstandard2.0\publish dist\Server\
xcopy /y /e NFive.Server\Config dist\config\
copy /y NFive.Server\nfive.lock dist\nfive.lock

del dist\Server\*.pdb
del dist\Server\*.deps.json

del dist\Client\*.pdb
del dist\Client\*.deps.json

copy Deps\Newtonsoft.Json.* dist\Client\
copy Deps\Newtonsoft.Json.* dist\Server\

mkdir dist\plugins\NFive\NFive.Test1
copy /y plugins\NFive.Test1.Client\bin\Release\net471\NFive.Test1.Client.net.dll dist\plugins\NFive\NFive.Test1\NFive.Test1.Client.net.dll
copy /y plugins\NFive.Test1.Server\bin\Release\netstandard2.0\NFive.Test1.Server.net.dll dist\plugins\NFive\NFive.Test1\NFive.Test1.Server.net.dll

mkdir dist\plugins\egertaia\street-position
copy /y plugins\StreetPosition\StreetPosition.Client\bin\Release\net471\StreetPosition.Client.net.dll dist\plugins\egertaia\street-position\StreetPosition.Client.net.dll
copy /y plugins\StreetPosition\StreetPosition.Server\bin\Release\netstandard2.0\StreetPosition.Server.net.dll dist\plugins\egertaia\street-position\StreetPosition.Server.net.dll
copy /y plugins\StreetPosition\StreetPosition.Shared\bin\Release\net471\StreetPosition.Shared.net.dll dist\plugins\egertaia\street-position\StreetPosition.Shared.net.dll

mkdir dist\plugins\egertaia\street-position\Overlays\
copy /y plugins\StreetPosition\StreetPosition.Client\bin\Release\net471\publish\Overlays\* dist\plugins\egertaia\street-position\Overlays\


rem xcopy /y /e dist\* G:\FiveM-Dev\HTB-RP\server-data\resources\NFiveHtb

