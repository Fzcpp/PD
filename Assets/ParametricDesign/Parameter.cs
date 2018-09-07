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

using UniRx;

namespace JL
{
	public abstract class Parameter
	{

		public IReactiveProperty<Parameter> Source = new ReactiveProperty<Parameter>();
		public IReactiveCollection<Parameter> Targets = new ReactiveCollection<Parameter>();
		public IReactiveProperty<object> Value = new ReactiveProperty<object>();

		public void SetSource(Parameter parameter)
		{
			Source.Value?.Targets.Remove(this);
			parameter?.Targets.Add(this);
			Source.Value = parameter;
		}

		public object GetReference()
		{
			return this;
		}

	    public int num = 10;
        public IReactiveProperty<object> GetValue()
        {
            return Value;
        }

	    public object GetValue_Value()
	    {
	        return Value.Value;
	    }
	}

	public class Parameter<T> : Parameter
	{
		public new IReactiveProperty<T> Value => base.Value as IReactiveProperty<T>;
	}
}