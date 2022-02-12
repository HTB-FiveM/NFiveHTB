namespace NFiveHtb.SDK.Client.Interface
{
	using System;
	using JetBrains.Annotations;

	
	public interface INuiManager
	{
		void Focus(bool hasFocus, bool showCursor);

		void Emit(object data);

		void On(string @event, Action action);

		void On<T>(string @event, Action<T> action);

		void On<TReturn>(string @event, Func<TReturn> action);

		void On<T, TReturn>(string @event, Func<T, TReturn> action);
	}
}
