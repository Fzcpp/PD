/*
 * 可绑定属性
 */



namespace JL
{

	public class BindableProperty<T>
	{

		public delegate void ValueChangedHandler(T oldValue, T newValue);

		public event ValueChangedHandler onValueChanged;

		private T _value;

		public T Value
		{
			get { return _value; }
			set
			{
				if (!Equals(_value, value))
				{
					T old = _value;
					_value = value;
					OnValueChanged(old, _value);
				}
			}
		}

		private void OnValueChanged(T oldValue, T newValue)
		{
			onValueChanged?.Invoke(oldValue, newValue);
		}

		public override string ToString()
		{
			return Value != null ? Value.ToString() : "null";
		}

		public void Clear()
		{
			onValueChanged = null;
		}

	}

}