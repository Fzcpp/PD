using UnityEngine;

namespace JL
{

	public enum WindowType
	{
		Null,
		Console
	}

	public static class WindowTypeJudger
	{

		public static WindowType GetViewType(object value)
		{
			if (value is int)
			{

			}

			return WindowType.Null;
		}

	}

	public interface IWindow
	{
		


	}

	public class ConsoleWindowView : MonoBehaviour, IWindow
	{

	}

}