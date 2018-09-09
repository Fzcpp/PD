using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LuaInterface;

namespace sunzhao
{
    public class CSharpCallLua
    {

        public object[] CallLuaFunc(string script, string funcName,object[] arguments)
        {
            LuaState luaState = new LuaState();
            luaState.DoString(script);

            LuaFunction func = luaState.GetFunction(funcName);
            object[] results = func.Call(arguments);
 
            return results;
        }
    }


}
