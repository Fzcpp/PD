using System.Collections.Generic;
using System.Linq;
using UniRx;

namespace JL
{

	public class Node
	{

		public IReactiveDictionary<string, Parameter> Parameters = new ReactiveDictionary<string, Parameter>();

		public IReactiveProperty<string> Script = new StringReactiveProperty();

		public IReactiveProperty<Parameter> ResultParameter = new ReactiveProperty<Parameter>();

		public List<View> Views;

		private readonly Script _script;

		public Node()
		{
			_script = new Script(Parameters);
			Script.Subscribe(x => { _script.Content = x; });
		}

		public void Execute()
		{
			_script.Execute();
			UpdateView();
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

		public void UpdateView()
		{
			
		}

		public void Dispose()
	    {
            _script.Dispose();
	    }

	}

}