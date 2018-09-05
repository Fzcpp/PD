/*
 * Dictionary<string,Parameter> Parameters
 * 其中 string 代表Lua脚本中的变量名
 * Parameter代表C#中的对象
 * 例如：
 * ("aaa",ParameterAAA)
 * 则进行如下转换：
 * ParameterAAA对应Lua脚本的xx_aaa
 * Lua脚本中，新加一行 aaa=xx_aaa.value
 */

namespace JL
{
	public abstract class Parameter
	{

		public object GetReference()
		{
			return this;
		}

	}

	public class Parameter<T> : Parameter
	{
		public T Value;
	}
}