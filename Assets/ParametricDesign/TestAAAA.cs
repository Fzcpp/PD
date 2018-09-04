using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAAAA : MonoBehaviour
{

	public int AAA =10;

	// Use this for initialization
	void Start () {
		Excutor a = new Excutor
		{
			Lua = new Lua
			{
				//aaa = AAA
			}
		};
		a.Excute();

		//希望得到AAA = 20
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}


public static class GlobalExcutor
{
	public static Dictionary<string,object> Map = new Dictionary<string, object>(); 
	public static void Change(string a)
	{
		Map[a] = (int)Map[a] + 10;
	}
}

public class Excutor
{
	public Lua Lua;

	public void Excute()
	{
		Lua.Change();
	}
}

/// <summary>
/// 命令式编程
/// </summary>
public class Lua
{
	public string aaaId;

	public void Change()
	{
		GlobalExcutor.Change(aaaId);
	}
}