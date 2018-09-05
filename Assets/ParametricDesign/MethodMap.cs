using System;
using System.Collections.Generic;

namespace JL
{
	public class MethodRegister
	{
		public Dictionary<string, Delegate> MethodMap = new Dictionary<string, Delegate>();

		public Delegate GetDelegate(string name)
		{
			return MethodMap[name];
		}

		public void AddMethodMapPair(string name, Action action)
		{
			MethodMap.Add(name, action);
		}

		public void AddMethodMapPair<T>(string name, Action<T> action)
		{
			MethodMap.Add(name, action);
		}

		public void AddMethodMapPair<T1, T2>(string name, Action<T1, T2> action)
		{
			MethodMap.Add(name, action);
		}

		public void AddMethodMapPair<T1, T2, T3>(string name, Action<T1, T2, T3> action)
		{
			MethodMap.Add(name, action);
		}

		public void AddMethodMapPair<T1, T2, T3, T4>(string name, Action<T1, T2, T3, T4> action)
		{
			MethodMap.Add(name, action);
		}

		public void AddMethodMapPair<T, TResult>(string name, Func<T, TResult> funcition)
		{
			MethodMap.Add(name, funcition);
		}

		public void AddMethodMapPair<T1, T2, TResult>(string name, Func<T1, T2, TResult> funcition)
		{
			MethodMap.Add(name, funcition);
		}

		public void AddMethodMapPair<T1, T2, T3, TResult>(string name, Func<T1, T2, T3, TResult> funcition)
		{
			MethodMap.Add(name, funcition);
		}

		public void AddMethodMapPairFunc<T1, T2, T3, T4, TResult>(string name, Func<T1, T2, T3, T4, TResult> funcition)
		{
			MethodMap.Add(name, funcition);
		}

		public void AddMethodMapPair<T1, T2, T3, T4, T5, TResult>(string name, Func<T1, T2, T3, T4, T5, TResult> funcition)
		{
			MethodMap.Add(name, funcition);
		}
	}
}