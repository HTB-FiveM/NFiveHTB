fx_version 'cerulean'
game 'gta5'

author 'Harry The Bastard'
version '1.0.0'
description 'Harry The Bastard\'s reworked version of the NFive plugin framework'

client_scripts {
	-- NFiveHtb
	'Client/**/*',
	'Client/netstandard.dll',

	-- Pugins
	'plugins/**/*.Shared.net.dll',
	'plugins/**/*.Client.net.dll'

}

server_scripts {
	-- NFiveHtb
	'Server/**/*',
	'Server/netstandard.dll',
	
	-- Pugins
	'plugins/**/*.Shared.net.dll',
	'plugins/**/*.Server.net.dll'
	
}

files {
	'Client/NFiveHtb.SDK.Plugins.dll',
	'Client/NFiveHtb.SDK.Core.dll',
	'Client/NFiveHtb.Client.net.dll',
	'Client/NGettext.dll',
	'Client/Newtonsoft.Json.dll',
	'Client/DotNetZip.dll',
	'Client/JetBrains.Annotations.dll',
	'Client/System.ComponentModel.Annotations.dll',
	'Client/netstandard.dll'


}

