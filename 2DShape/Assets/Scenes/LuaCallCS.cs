using System.Collections;
using System.Collections.Generic;
using LuaInterface;
using UnityEngine;
 
public class LuaCallCS : MonoBehaviour
{
    private string script = @"
              --require 'luanet'
              luanet.load_assembly('Assembly-CSharp')
              luanet.load_assembly('UnityEngine')
               
              pro=luanet.import_type('Program')
              
        ";

	// Use this for initialization
	void Start () {
	    LuaState luaState=new LuaState();
	     
        // luaState.RegisterFunction();
        Program program=new Program();
	    luaState.DoString(script);
        ////注册普通方法
	   // luaState.RegisterFunction("Double", program, program.GetType().GetMethod("Double"));
	    //luaState.DoString(" print(Double(32))");

        /////////注册静态方法
	    luaState.RegisterFunction("Add", null, program.GetType().GetMethod("Add"));
	    luaState.DoString(" print( Add(32,234))");
        /////////获取C#对象
	    luaState.RegisterFunction("getInstance", null, program.GetType().GetMethod("getInstance"));
	    luaState.DoString("pro=getInstance()");
        luaState.DoString(" print( pro.count)");

	    luaState.DoString("print(pro:getCount() )");

	    luaState.DoString("print( pro:Double(234) )");
	}

    // Update is called once per frame
    void Update () {
		
	}
}
