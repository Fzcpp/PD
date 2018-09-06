using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using JL;
using UniRx;
using UnityEngine;

public class TestBBBB : MonoBehaviour {

	// Use this for initialization
	void Start () {

		

		Node node = new Node();
		node.Parameter= new TestDataParameter("Hello", 3);
		node.LuaScript = new LuaScript(new ScriptFile("D:\\aaa.txt"));
		Config.AddMethodMapPair("GetSum", ((TestDataParameter)node.Parameter).GetSum);
		object obj=node.LuaScript.CallFunction(node.Parameter, "GetRef", null);
		//Debug.Log(node.LuaScript._luaState["csObj"]);
		//node.LuaScript.CallLuaScript();

		//Debug.Log(((TestDataParameter)node.Parameter).Value.Value.BBB);

        //////////////////////
        Debug.Log("test begin:");
	    IDictionary<string, Parameter> parameters=new Dictionary<string, Parameter>();
        Parameter  parameter=new JL.Parameter<int>()   ;
	    parameter.Value =new ReactiveProperty<object>();
	    parameter.Value.Value = 15;
        parameters.Add("first",parameter);
        print(parameter.Value);
	    print(parameter.Value.Value);
        Script script=new Script(parameters);
        script.test("first");

    }

	



}
