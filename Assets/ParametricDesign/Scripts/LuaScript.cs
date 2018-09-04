﻿using System.Runtime.InteropServices;
using LuaInterface;

public class LuaScript
{

	private readonly LuaState _luaState = new LuaState();

	public ScriptFile _scriptFile;

	public LuaScript(ScriptFile scriptFile)
	{
		_scriptFile = scriptFile;
	}

	public string GetArgumentsScript(object[] arguments)
	{
		string allParams = "";
		if (arguments != null)
		{
			for (int i = 0; i < arguments.Length; i++)
			{
				if (i == 0)
					allParams += "(";
				allParams += arguments[i];
				if (i < arguments.Length - 1)
					allParams += ",";
				else allParams += ")";
			}
		}

		return allParams;
	}

	// 静态方法
	public object CallStaticFunc(string script, object csObject, string funcName, object[] arguments)
	{
		_luaState.DoString(script);
		////注册静态方法
		_luaState.RegisterFunction(funcName, null, csObject.GetType().GetMethod(funcName));

		string allParams = GetArgumentsScript(arguments);
		_luaState.DoString(" result=" + funcName + allParams);

		object result = _luaState["result"];
		return result;
	}

	public void RegisterFunctionAttribute()
	{

	}

	// 不能调用静态方法
	public object CallFunction(object csObject, string funcName, object[] arguments)
	{
		_luaState.DoString(_scriptFile.getFileInfo());
		string getRefFunc = "GetRef";
		_luaState.RegisterFunction(getRefFunc, csObject, csObject.GetType().GetMethod(getRefFunc));

		_luaState.DoString("csObj=GetRef()");
		string allParams = GetArgumentsScript(arguments);
		_luaState.DoString(" result=csObj:" + funcName + allParams);

		return _luaState["result"];
	}

	// 执行lua 脚本
	public void CallLuaScript()
	{
		_luaState.DoString(_scriptFile.getFileInfo());
	}
}