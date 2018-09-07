using LuaInterface;
using System.Collections.Generic;

namespace JL
{

	public class Script
	{

		private IDictionary<string, Parameter> _parameters;

		public readonly LuaState _luaState = new LuaState();

		public string Content;

		public Script(IDictionary<string, Parameter> parameters)
		{
			_parameters = parameters;
		}

	    public void test(string name )
	    {
			
	        string getRefFunc = "GetReference";
	        Parameter parameter = _parameters[name];
	        _luaState.RegisterFunction(getRefFunc, parameter, parameter.GetType().GetMethod(getRefFunc));

            string objName = "obj"; // 对象名字为 name_obj 的形式

            _luaState.DoString(objName+"= "+getRefFunc+"()");
		    _luaState.DoString(objName + ":SetValue(122)");
		    _luaState.DoString("first" + "= " + objName + ":GetValue()");
		    _luaState.DoString(objName + ":SetValue(first + config:GetDelegate('GetSum2'):Invoke(100,100))");
		}
		public void Execute()
		{
			_luaState.DoString(Content);
		}

	}

}