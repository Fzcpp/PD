using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JL
{

	public class NodeView : MonoBehaviour
	{

		public GraphView Parent;

		public List<ParameterView> ParameterViewList;

		public ScriptView ScriptView;

		public ConsoleWindowView ConsoleWindowView;

		public Node Node = new Node();

		public NodeView()
		{
			Node.Parameters.Add("fanzheng",new Parameter<int>());
			Node.Parameters.Add("sunzhao",new Parameter<int>());
		}

	}

}