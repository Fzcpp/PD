using System.Collections.Generic;
using System.Linq;
using UniRx;

namespace JL
{

	public class Graph : Node
	{

		public IReactiveCollection<Node> Nodes = new ReactiveCollection<Node>();

	    public Dictionary<int, Node> StartNodes = new Dictionary<int, Node>();

		public void AddNode(Node node)
		{
			Nodes.Add(node);
		}

		public void RemoveNode(Node node)
		{
		    node.Dispose();
            Nodes.Remove(node);
		}

	    public new void Execute()
	    {
            //todo 待补全
            HashSet<Node> dirtyNodes = new HashSet<Node>();
	        var priorityList = StartNodes.Keys.OrderByDescending(t => t);
	        foreach (var priority in priorityList)
	        {
                var startNode = StartNodes[priority];
	            startNode.Execute();
	            dirtyNodes.Add(startNode);
	        }
	    }

	}

}