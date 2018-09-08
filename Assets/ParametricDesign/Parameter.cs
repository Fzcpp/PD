using System;
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

	    public object GetRef()
		{
			return this;
		}

		public object GetValue()
		{
			return Value.Value;
		}

		public void SetValue(object value)
		{
			Value.Value = value;
		}

	}

	public class Parameter<T> : Parameter
	{
		public new IReactiveProperty<T> Value => base.Value as IReactiveProperty<T>;
	}

}