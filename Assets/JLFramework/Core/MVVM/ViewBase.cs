/*
 * View的基类
 */



using System;
using UnityEngine;

namespace JL
{

	public interface IView<T> where T : ViewModelBase
	{
		T ViewModel { get; set; }
		void Appear(Action action = null);
		void Disappear(Action action = null);
	}

	public abstract class ViewBase<T> : MonoBehaviour, IView<T> where T : ViewModelBase
	{

		private bool _isInitialized;
		private readonly BindableProperty<T> _viewModel = new BindableProperty<T>();
		protected readonly PropertyBinder<T> Binder = new PropertyBinder<T>();

		public T ViewModel
		{
			get { return _viewModel.Value; }
			set
			{
				if (!_isInitialized)
				{
					OnInitialize();
					_isInitialized = true;
				}

				_viewModel.Value = value;
			}
		}

		public void Appear(Action action = null)
		{
			ViewModel.OnAppearing();
			action?.Invoke();
		}

		public void Disappear(Action action = null)
		{
			ViewModel.OnDisappearing();
			action?.Invoke();
		}

		protected virtual void OnInitialize()
		{
			_viewModel.onValueChanged += OnViewModelChanged;
		}

		protected virtual void OnViewModelChanged(T oldValue, T newValue)
		{
			Binder.Unbind(oldValue);
			Binder.Bind(newValue);
		}

		public virtual void OnDestroy()
		{
			if (ViewModel.IsAppeared)
			{
				Disappear();
			}

			ViewModel.OnDestory();
			ViewModel = null;
			_viewModel.Clear();
		}

	}

}