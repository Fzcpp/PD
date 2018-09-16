using System.Collections;
using System.Collections.Generic;
using JL;
using UnityEngine;
using UnityEngine.UI;

public class ScriptView : MonoBehaviour
{

	public NodeView Parent;

	public InputField ScriptInputField;

	// Use this for initialization
	void Start () {
		ScriptInputField.onEndEdit.AddListener(Execute);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Execute(string scrpit)
	{
		Debug.Log("scrpit: " + scrpit);
		Parent.Node.Script.Value = scrpit;
		Parent.Node.Execute();
	}

}
