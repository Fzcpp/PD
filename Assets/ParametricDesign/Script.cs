using LuaInterface;
using System.Collections.Generic;

//TODO: 1） lua里的参数名与Parameter的Value对应
//TODO: 2） lua里的参数名与Parameter的Value对应

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