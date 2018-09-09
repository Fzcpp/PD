using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config
{

	public static readonly Config Instance = new Config();

	public Dictionary<string, Delegate> MethodMap = new Dictionary<string, Delegate>();

	public void AddMethodMapPair(string luaMethodName, Func<float, float, float> csharpMethod)
	{
		MethodMap.Add(luaMethodName, csharpMethod);
	}

	public Delegate GetDelegate(string name)
	{
		return MethodMap[name];
	}

	public float GetSum(float op1, float op2)
	{
		return op1 + op2;
	}

	public object GetRef()
	{
		return this;
	}

}