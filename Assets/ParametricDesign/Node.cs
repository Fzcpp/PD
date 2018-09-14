using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;

namespace JL
{

	public class Node
	{

		public event Action onScriptExecuted;

		public IReactiveDictionary<string, Parameter> Parameters = new ReactiveDictionary<string, Parameter>();

		public IReactiveProperty<string> Script = new StringReactiveProperty();

		private readonly Script _script;

		public Node()
		{
			_script = new Script(Parameters);
			Script.Subscribe(x =>
			{
				_script.Content = x;
			});
		}

		public void Execute()
		{
			_script.Execute();
			onScriptExecuted?.Invoke();
		}

		public bool AddParameter(string name, Parameter parameter)
		{
			if (Parameters.ContainsKey(name))
			{
				return false;
			}

			Parameters.Add(name, parameter);
			return true;
		}

		public void RemoveParameter(string name)
		{
			Parameters.Remove(name);
		}

		public List<Node> GetTargets()
		{
			return Parameters.Select(t => t.Value.Node).ToList();
		}

		public void Dispose()
	    {
            _script.Dispose();
	    }

	}

}