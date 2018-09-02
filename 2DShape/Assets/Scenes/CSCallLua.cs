using System.Collections;
using System.Collections.Generic;
using LuaInterface;
using UnityEngine;

public class CSCallLua : MonoBehaviour
{
    private string script = @"
            function luaFunc(msg)
                print(msg)
                return 1,2,3
            end
           ";
	// Use this for initialization
	void Start () {
		LuaState luaState=new LuaState();
	    luaState.DoString(script);

	    LuaFunction func = luaState.GetFunction("luaFunc");
	    object[] objects =func.Call("call a lua function");
	    foreach (var obj in objects)
	    {
	        print(obj);
	    }
	   
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
