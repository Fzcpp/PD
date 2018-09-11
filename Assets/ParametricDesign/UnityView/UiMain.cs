using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiMain : MonoBehaviour
{

	public static UiMain Instance;

	#region sub views

	public NodeLibraryView NodeLibraryView;

	public List<GraphView> GraphViewList;

	public GraphManagerView GraphManagerView;

	#endregion

	#region prefabs

	public GameObject NodeTemplatePrefab;

	public GameObject NodePrefab;

	#endregion

	public GraphView CurrentGraphView;

	void Awake()
	{
		Instance = this;
	}

}