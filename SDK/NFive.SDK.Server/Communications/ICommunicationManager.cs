﻿namespace NFive.SDK.Server.Communications
{
	using JetBrains.Annotations;

	
	public interface ICommunicationManager
	{
		ICommunicationTarget Event(string @event);
	}
}