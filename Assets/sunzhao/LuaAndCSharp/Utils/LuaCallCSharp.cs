using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LuaInterface;
using UnityEngine.Experimental.PlayerLoop;

public class LuaCallCSharp
{
    private LuaState luaState = new LuaState();
    private ScriptFile scriptFile;
    public string GetArgumentsScript(object[] arguments)
    {
        string allParams = "(";
        if (arguments != null)
        {
            for (int i = 0; i < arguments.Length; i++)
            {      
                allParams += arguments[i];
                if (i < arguments.Length - 1)
                    allParams += ",";          
            }
        }
        allParams += ")";
        return allParams;
    }
    
    // 静态方法
    public object CallStaticFunc(string script, object csObject, string funcName, object[] arguments)
    {
        luaState.DoString(script);
        ////注册静态方法
        luaState.RegisterFunction(funcName, null, csObject.GetType().GetMethod(funcName));

        string allParams = GetArgumentsScript(arguments);
        luaState.DoString(" result=" + funcName + allParams);

        object result = luaState["result"];
        return result;
    }

    // 不能调用静态方法
    public object CallFunction(ScriptFile script,object csObject, string funcName, object[] arguments)
    {
        this.scriptFile = script;
        if (scriptFile != null)  
            luaState.DoString(scriptFile.getFileInfo());
        
        
        string getRefFunc = "getRef";
        luaState.RegisterFunction(getRefFunc, csObject, csObject.GetType().GetMethod(getRefFunc));
   
        luaState.DoString("csObj=getRef()");
        string allParams = GetArgumentsScript(arguments);
        luaState.DoString(" result=csObj:" + funcName + allParams);
    
        return luaState["result"];
    }
    // 执行lua 脚本
    public void CallLuaScript()
    {
        luaState.DoString(scriptFile.getFileInfo());
    }
}
