/*
 * 消息中介器
 */



using System;
using System.Collections.Generic;

namespace PD
{

	public class MessageMediator
	{
		private readonly Dictionary<string, Delegate> _messageMap = new Dictionary<string, Delegate>();

		#region internal methods

		private void RegisterMessageInternal(string messageName, Delegate handler)
		{
			Delegate prevHandlers;
			if (_messageMap.TryGetValue(messageName, out prevHandlers))
			{
				_messageMap[messageName] = Delegate.Combine(prevHandlers, handler);
			}
			else
			{
				_messageMap.Add(messageName, handler);
			}
		}

		private Delegate GetDelegateInternal(string messageName)
		{
			Delegate handler;
			if (_messageMap.TryGetValue(messageName, out handler))
			{
				return handler;
			}

			return null;
		}

		private void UnregisterMessageInternal(string messageName, Delegate handler)
		{
			Delegate prevHandlers;
			if (_messageMap.TryGetValue(messageName, out prevHandlers))
			{
				_messageMap[messageName] = Delegate.Remove(prevHandlers, handler);
			}
		}

		#endregion



		#region register message

		public void RegisterMessage(string messageName, Action handler)
		{
			RegisterMessageInternal(messageName, handler);
		}

		public void RegisterMessage<T>(string messageName, Action<T> handler)
		{
			RegisterMessageInternal(messageName, handler);
		}

		public void RegisterMessage<T1, T2>(string messageName, Action<T1, T2> handler)
		{
			RegisterMessageInternal(messageName, handler);
		}

		public void RegisterMessage<T1, T2, T3>(string messageName, Action<T1, T2, T3> handler)
		{
			RegisterMessageInternal(messageName, handler);
		}

		public void RegisterMessage<T1, T2, T3, T4>(string messageName, Action<T1, T2, T3, T4> handler)
		{
			RegisterMessageInternal(messageName, handler);
		}

		#endregion



		#region send message

		public void SendMessage(string messageName)
		{
			(GetDelegateInternal(messageName) as Action)?.Invoke();
		}

		public void SendMessage<T>(string messageName, T arg1)
		{
			(GetDelegateInternal(messageName) as Action<T>)?.Invoke(arg1);
		}

		public void SendMessage<T1, T2>(string messageName, T1 arg1, T2 arg2)
		{
			(GetDelegateInternal(messageName) as Action<T1, T2>)?.Invoke(arg1, arg2);
		}

		public void SendMessage<T1, T2, T3>(string messageName, T1 arg1, T2 arg2, T3 arg3)
		{
			(GetDelegateInternal(messageName) as Action<T1, T2, T3>)?.Invoke(arg1, arg2, arg3);
		}

		public void SendMessage<T1, T2, T3, T4>(string messageName, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			(GetDelegateInternal(messageName) as Action<T1, T2, T3, T4>)?.Invoke(arg1, arg2, arg3, arg4);
		}

		#endregion



		#region unregister message

		public void UnregisterMessage(string messageName, Action handler)
		{
			UnregisterMessageInternal(messageName, handler);
		}

		public void UnregisterGlobalEvent<T>(string messageName, Action<T> handler)
		{
			UnregisterMessageInternal(messageName, handler);
		}

		public void UnregisterGlobalEvent<T1, T2>(string messageName, Action<T1, T2> handler)
		{
			UnregisterMessageInternal(messageName, handler);
		}

		public void UnregisterGlobalEvent<T1, T2, T3>(string messageName, Action<T1, T2, T3> handler)
		{
			UnregisterMessageInternal(messageName, handler);
		}

		public void UnregisterGlobalEvent<T1, T2, T3, T4>(string messageName, Action<T1, T2, T3, T4> handler)
		{
			UnregisterMessageInternal(messageName, handler);
		}

		#endregion

	}

}