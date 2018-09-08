namespace JL
{

	public enum ViewType
	{
		Null,

	}


	public static class ViewTypeJudger
	{

		public static ViewType GetViewType(object value)
		{
			if (value is int)
			{

			}

			return ViewType.Null;
		}

	}
	
}