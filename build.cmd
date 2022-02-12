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
xcopy /y /e NFiveHtb.Client\bin\Release\net471\publish dist\Client\
xcopy /y /e NFiveHtb.Server\bin\Release\netstandard2.0\publish dist\Server\
xcopy /y /e NFiveHtb.Server\Config dist\config\
copy /y NFiveHtb.Server\nfive.lock dist\nfive.lock

del dist\Server\*.pdb
del dist\Server\*.deps.json

del dist\Client\*.pdb
del dist\Client\*.deps.json

mkdir dist\plugins\NFive\NFiveHtb.Test1
copy /y plugins\NFiveHtb.Test1.Client\bin\Release\net471\NFiveHtb.Test1.Client.net.dll dist\plugins\NFive\NFiveHtb.Test1\NFiveHtb.Test1.Client.net.dll
copy /y plugins\NFiveHtb.Test1.Server\bin\Release\netstandard2.0\NFiveHtb.Test1.Server.net.dll dist\plugins\NFive\NFiveHtb.Test1\NFiveHtb.Test1.Server.net.dll

xcopy /y /e dist\* G:\FiveM-Dev\HTB-RP\server-data\resources\NFiveHtb

