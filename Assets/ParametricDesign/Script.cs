using LuaInterface;
using System.Collections.Generic;

//TODO: 1） lua里的参数名与Parameter的Value对应
//TODO: 2） lua里的参数名与Parameter的Value对应

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

            string objName = name + "_obj"; // 对象名字为 name_obj 的形式
            _luaState.DoString(objName+"= "+getRefFunc+"()");

	       
	        _luaState.DoString("print(" + objName + ".num)");
            // 这里直接使用.Value 只会获得一个空引用，原因不明
	        _luaState.DoString("value=" +objName+ ":GetValue()  ");
	        _luaState.DoString("print('Value')");
	        _luaState.DoString("print(value)");

            string valName = name + "_value";// 变量名字用name_value表示 
	        _luaState.DoString("print('Value.Value :')");
	        _luaState.DoString(valName + "=" + objName + ":GetValue_Value() ");
	        _luaState.DoString("print(" + valName + ")");
	    }
		public void Execute()
		{
			_luaState.DoString(Content);
		}

	}
}