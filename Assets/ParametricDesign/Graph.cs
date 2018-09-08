using UniRx;

namespace JL
{

	public class Graph : Node
	{

		public IReactiveCollection<Node> Nodes = new ReactiveCollection<Node>();

		public void AddNode(Node node)
		{
			Nodes.Add(node);
		}

		public void RemoveNode(Node node)
		{
		    node.Dispose();
            Nodes.Remove(node);
		}

	}

}