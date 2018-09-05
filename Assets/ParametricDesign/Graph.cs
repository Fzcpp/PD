using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JL
{
	public class Graph : Node
	{

		public List<Connection> Connections;

		public Dictionary<string, Node> Nodes;

		public Graph(string name) : base(name)
		{
			Connections = new List<Connection>();
			Nodes = new Dictionary<string, Node>();
		}

	}
}