using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JL
{

	public class Node
	{

		public string Name;

		public Dictionary<string, Parameter> Parameters;

		public Script Script;

		public Node(string name)
		{
			Name = name;
			Parameters = new Dictionary<string, Parameter>();
			Script = new Script(Parameters);
		}

		public void AddParameter(string name, Parameter parameter)
		{

		}

		public void RemoveParameter(string name)
		{

		}

	}

}