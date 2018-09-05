using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Config
{

	public static Dictionary<string, Func<float, float, float>> MethodMap = new Dictionary<string, Func<float, float, float>>();

	public static void AddMethodMapPair(string luaMethodName, Func<float, float, float> csharpMethod)
	{
		MethodMap.Add(luaMethodName, csharpMethod);
	}


	

}