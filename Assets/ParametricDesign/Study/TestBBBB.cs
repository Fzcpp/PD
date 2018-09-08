using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using JL;
using UniRx;
using UnityEngine;

public class TestBBBB : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{
		Config.Instance.AddMethodMapPair("GetSum2",Config.Instance.GetSum);
		Debug.Log("test begin:");
	    ReactiveDictionary<string, Parameter> parameters = new ReactiveDictionary<string, Parameter>();
		Parameter parameter = new JL.Parameter<int>();
		parameter.Value = new ReactiveProperty<object>();
		parameter.Value.Value = 15;
		parameters.Add("first", parameter);
		Script script = new Script(parameters);
		script._luaState.RegisterFunction("GetConfigInstance", Config.Instance, Config.Instance.GetType().GetMethod("GetRef"));
		script._luaState.DoString("config=GetConfigInstance()");
		script.test("first");

		print("Value : " + script._luaState["first"]);
		print("C# Value: " + parameter.Value.Value);
	}





}