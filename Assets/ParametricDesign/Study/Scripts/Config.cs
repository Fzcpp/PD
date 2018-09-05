using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Config
{

	public static Dictionary<string, Delegate> MethodMap = new Dictionary<string, Delegate>();

	public static void AddMethodMapPair(string luaMethodName, Func<float, float, float> csharpMethod)
	{
		MethodMap.Add(luaMethodName, csharpMethod);
	}

	public static Delegate GetDelegate(string name)
	{
		return MethodMap[name];
	}


}