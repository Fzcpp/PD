using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBBBB : MonoBehaviour {

	// Use this for initialization
	void Start () {

		//Config.AddMethodMapPair("",Update);

		Node node = new Node();
		node.Parameter= new TestDataParameter("Hello", 3);
		node.LuaScript = new LuaScript(new ScriptFile("D:\\aaa.txt"));

		object obj=node.LuaScript.CallFunction(node.Parameter, "GetRef", null);

		 
		node.LuaScript.CallLuaScript();
	}
	
	void Update () {
		
	}

	

}
