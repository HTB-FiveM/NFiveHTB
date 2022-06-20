fx_version 'cerulean'
game 'gta5'

author 'Harry The Bastard'
version '1.0.0'
description 'Harry The Bastard\'s reworked version of the NFive plugin framework'

server_scripts {
	-- NFiveHtb
	'Server/NFive.Server.net.dll'

}

client_scripts {
	-- NFiveHtb
	'Client/NFive.Client.net.dll',

	-- Plugins
	'plugins/**/*.Shared.net.dll',
	'plugins/**/*.Client.net.dll'

}

files {	
	'Client/DotNetZip.dll',
	'Client/JetBrains.Annotations.dll',
	'Client/Newtonsoft.Json.dll',
	--'Client/NFive.SDK.Plugins.dll',
	'Client/NFive.SDK.Client.dll',
	'Client/NFive.SDK.Core.dll',
	'Client/NGettext.dll',
	'index.html',


	-- egertaia/street-position@1.2.1
	'plugins/egertaia/street-position/Overlays/StreetPositionOverlay.html',
	'plugins/egertaia/street-position/Overlays/style.css',

}
-- NFive
ui_page 'index.html'
