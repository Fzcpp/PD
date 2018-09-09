using System;
using LuaInterface;
using System.Collections.Generic;
using UniRx;

namespace JL
{

	public class Script
	{

		private readonly IReactiveDictionary<string, Parameter> _parameters;

		public readonly LuaState _luaState = new LuaState();

		public string Content;

		#region temp

		private List<IDisposable> _disposables;

		#endregion

		public Script(IReactiveDictionary<string, Parameter> parameters)
		{
			_parameters = parameters;
			_disposables.Add(_parameters.ObserveAdd().Subscribe(OnAddParameter));
			_disposables.Add(_parameters.ObserveRemove().Subscribe(OnRemoveParameter));
			_disposables.Add(AoManager.Instance.AoPackages.ObserveAdd().Subscribe(OnAddAoPackage));
			_disposables.Add(AoManager.Instance.AoPackages.ObserveRemove().Subscribe(OnRemoveAoPackage));
			RegisterInitialize();
		}

		private void RegisterInitialize()
		{
			foreach (var aoPackage in AoManager.Instance.AoPackages)
			{
				RegisterAoPackage(aoPackage);
			}

			foreach (var pair in _parameters)
			{
				RegisterParameter(pair.Key, pair.Value);
			}
		}

		private void RegisterAoPackage(AoPackage aoPackage)
		{
			string getRef = "GetRef_" + aoPackage.Name;
			_luaState.RegisterFunction(getRef, aoPackage,
				aoPackage.GetType().GetMethod("GetRef"));
			_luaState.DoString(aoPackage.Name + "=" + getRef + "()");
		}

		private void RegisterParameter(string name, Parameter parameter)
		{
			string getRef = "GetRef_" + name;
			_luaState.RegisterFunction(getRef, parameter,
				parameter.GetType().GetMethod("GetRef"));
			_luaState.DoString(name + "=" + getRef + "()");
		}

		private void UnregisterAoPackage(AoPackage aoPackage)
		{
		    string getRef = "GetRef_" + aoPackage.Name;
		    _luaState.DoString(getRef + "=nil");
		    _luaState.DoString(aoPackage.Name + "=nil");

        }

		private void UnregisterParameter(string name)
		{
		    string getRef = "GetRef_" + name;
		    _luaState.DoString(getRef + "=nil");
		    _luaState.DoString(name + "=nil");
		}

        private void OnAddParameter(DictionaryAddEvent<string, Parameter> parameterAddEvent)
		{
			RegisterParameter(parameterAddEvent.Key, parameterAddEvent.Value);
		}

		private void OnRemoveParameter(DictionaryRemoveEvent<string, Parameter> parameterRemoveEvent)
		{
		    UnregisterParameter(parameterRemoveEvent.Key);

		}

		private void OnAddAoPackage(CollectionAddEvent<AoPackage> aoPackageAddEvent)
		{
			RegisterAoPackage(aoPackageAddEvent.Value);
		}

		private void OnRemoveAoPackage(CollectionRemoveEvent<AoPackage> aoPackageRemoveEvent)
		{
            UnregisterAoPackage(aoPackageRemoveEvent.Value);
		}

		public void Dispose()
		{
			foreach (var disposable in _disposables)
			{
				disposable.Dispose();
			}
		}

		public void test(string name)
		{

			string getRefFunc = "GetReference";
			Parameter parameter = _parameters[name];
			_luaState.RegisterFunction(getRefFunc, parameter, parameter.GetType().GetMethod(getRefFunc));

			string objName = "obj"; // 对象名字为 name_obj 的形式

			_luaState.DoString(objName + "= " + getRefFunc + "()");
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