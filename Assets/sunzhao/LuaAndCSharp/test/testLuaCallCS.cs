using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testLuaCallCS : MonoBehaviour {

	// Use this for initialization
	void Start () {
		LuaCallCSharp callCS=new LuaCallCSharp();
         
	    Program pro = new Program();
	    pro.GetRef();
        string script = "";
        object[] arguments=null;
	   
	    arguments = new object[] {  4, 265 };
	    object result = callCS.CallStaticFunc(script, pro, "Add", arguments);
	    print(result);
        /////////////////////
	    arguments = new object[] { 2344, 265 };
       
        ScriptFile scriptFile=new ScriptFile("firstScript.txt");
        scriptFile.AddScript("print('hello world')");

        result = callCS.CallFunction(scriptFile, pro, "Sub", arguments);
        print(result);
        //在调用C#函数之后调用lua脚本
        scriptFile.AddScript("print('lua scipt:',result)");

        callCS.CallLuaScript();
        scriptFile.ClearAllScripts();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
