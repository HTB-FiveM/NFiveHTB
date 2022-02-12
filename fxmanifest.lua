fx_version 'cerulean'
game 'gta5'

author 'Harry The Bastard'
version '1.0.0'
description 'Harry The Bastard\'s reworked version of the NFive plugin framework'

client_scripts {
	-- NFiveHtb
	'Client/**/*',

	-- Pugins
	'plugins/**/*.Shared.net.dll',
	'plugins/**/*.Client.net.dll'

}

server_scripts {
	-- NFiveHtb
	'Server/**/*',
	
	-- Pugins
	'plugins/**/*.Shared.net.dll',
	'plugins/**/*.Server.net.dll'

}

files {
	

}

