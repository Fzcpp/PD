using System.Collections;
using System.Collections.Generic;
using LuaInterface;
using UnityEngine;

namespace JL
{
	public class Script
	{

		private Dictionary<string, Parameter> _parameters;

		private readonly LuaState _luaState = new LuaState();

		public string Content;

		public Script(Dictionary<string, Parameter> parameters)
		{
			_parameters = parameters;
		}

		public void Execute()
		{
			_luaState.DoString(Content);
		}

	}
}