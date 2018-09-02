/*
 * ViewModel的基类
 */



namespace PD
{

	public abstract class ViewModelBase
	{

		private bool _isInitialized;
		public ViewModelBase ParentViewModel { get; set; }
		public bool IsAppeared { get; private set; }
		protected abstract void OnInitialize();
		public abstract void OnDestory();

		public virtual void OnAppearing()
		{
			if (!_isInitialized)
			{
				OnInitialize();
				_isInitialized = true;
			}

			IsAppeared = true;
		}

		public virtual void OnDisappearing()
		{
			IsAppeared = false;
		}

	}

	public static class ViewModelBaseExtensions
	{

		public static T GetAncestor<T>(this ViewModelBase origin) where T : ViewModelBase
		{
			var parentViewModel = origin?.ParentViewModel;
			while (parentViewModel != null)
			{
				var castedViewModel = parentViewModel as T;
				if (castedViewModel != null)
				{
					return castedViewModel;
				}

				parentViewModel = parentViewModel.ParentViewModel;
			}

			return null;
		}

	}

}