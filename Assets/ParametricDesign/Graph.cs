using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JL
{
	public class Graph : Node
	{

		public List<Connection> Connections;

		public List<Node> Nodes;

		public Graph(string name) : base(name)
		{
			Connections = new List<Connection>();
			Nodes = new List<Node>();
		}

		public void AddNode(Node node)
		{

		}

		public void RemoveNode(Node node)
		{

		}

		public void Connect(Parameter from, Parameter to)
		{

		}

		public void Disconnect(Parameter from, Parameter to)
		{

		}

	}
}