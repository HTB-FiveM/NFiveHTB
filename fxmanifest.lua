fx_version 'cerulean'
game 'gta5'

author 'Harry The Bastard'
version '1.0.0'
description 'Harry The Bastard\'s reworked version of the NFive plugin framework'

server_scripts {
	-- NFiveHtb
	'Server/NFiveHtb.Server.net.dll'

}

client_scripts {
	-- NFiveHtb
	'Client/NFiveHtb.Client.net.dll',

	-- Plugins
	'plugins/**/*.Client.net.dll'

}

files {	
	'Client/DotNetZip.dll',
	'Client/JetBrains.Annotations.dll',
	'Client/Newtonsoft.Json.dll',
	--'Client/NFiveHtb.SDK.Plugins.dll',
	'Client/NFiveHtb.SDK.Client.dll',
	'Client/NFiveHtb.SDK.Core.dll',
	'Client/NGettext.dll'


}

