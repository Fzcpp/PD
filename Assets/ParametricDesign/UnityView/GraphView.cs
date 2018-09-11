using System.Collections.Generic;
using UnityEngine;

public class GraphView : MonoBehaviour
{

	public UiMain Parent;

	public List<NodeView> NodeViewList;

	public List<ConnectionView> ConnectionViewList;

	public Transform NodeParent;

	private void Awake()
	{
		NodeParent = transform.Find("Nodes");
	}

	public void AddNodeView(Node node = null)
	{
		if (node == null)
		{
			var nodeView = Instantiate(UiMain.Instance.NodePrefab).GetComponent<NodeView>();
			nodeView.transform.SetParent(NodeParent, false);
			NodeViewList.Add(nodeView);
		}
	}

}