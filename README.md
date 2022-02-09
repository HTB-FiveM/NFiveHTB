# nfive-htb

nfive-htb project is a re-work by Harry The Bastard of the NFive.io plugin system for FiveM

To edit it, open `htb_rp.sln` in Visual Studio.

To build it, run `build.cmd`. To run it, run the following commands to make a symbolic link in your server data directory:

```dos
cd /d [PATH TO THIS RESOURCE]
mklink /d X:\cfx-server-data\resources\[local]\htb_rp dist
```

Afterwards, you can use `ensure nfive-htb` in your server.cfg or server console to start the resource.
