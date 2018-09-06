using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBBBB : MonoBehaviour {

	// Use this for initialization
	void Start () {

		

		Node node = new Node();
		node.Parameter= new TestDataParameter("Hello", 3);
		node.LuaScript = new LuaScript(new ScriptFile("D:\\aaa.txt"));
		Config.AddMethodMapPair("GetSum", ((TestDataParameter)node.Parameter).GetSum);
		object obj=node.LuaScript.CallFunction(node.Parameter, "GetRef", null);
		Debug.Log(node.LuaScript._luaState["csObj"]);
		node.LuaScript.CallLuaScript();

		Debug.Log(((TestDataParameter)node.Parameter).Value.Value.BBB);
	}

	



}
