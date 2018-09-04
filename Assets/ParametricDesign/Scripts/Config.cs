using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Config
{

	public static Dictionary<string, Delegate> MethodMap = new Dictionary<string, Delegate>();

	public static Dictionary<string, object> ObjectMap = new Dictionary<string, object>();

	public static void AddMethodMapPair(string luaMethodName, Delegate csharpMethod)
	{
		
	}


}