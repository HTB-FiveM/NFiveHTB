﻿namespace NFive.SDK.Server.Events
{
	using JetBrains.Annotations;

	
	public interface IConnectionDeferrals
	{
		string Message { set; }

		void Defer();

		void ShowCard(string json);

		void Allow();

		void Reject(string message);
	}
}