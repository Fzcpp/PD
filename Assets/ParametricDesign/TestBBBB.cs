using System.Collections;
using System.Collections.Generic;
using LuaInterface;
using UnityEngine;

public class TestBBBB : MonoBehaviour {

	// Use this for initialization
	void Start () {

		//Config.AddMethodMapPair("",Update);

		Node node = new Node();
		node.Parameter= new TestDataParameter("Hello", 3);
		node.LuaScript = new LuaScript(new ScriptFile("D:\\aaa.txt"));

        object result =node.LuaScript.CallFunction(node.Parameter, "GetValue", new Object[]{});
        
	    node.LuaScript.CallLuaScript();
        /* Program pro = new Program();
        object[] paras = new object[] { 2344, 265 };
       
        node.LuaScript.CallFunction(pro, "Sub", paras);
        
        */
    }
	
	void Update () {
		
	}

	

}
