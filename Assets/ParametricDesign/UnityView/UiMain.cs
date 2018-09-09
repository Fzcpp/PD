using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiMain : MonoBehaviour
{

	public static UiMain Instance;

	public NodeLibraryView NodeLibraryView;

	public List<GraphView> GraphViewList;

	public GraphManagerView GraphManagerView;

	void Awake()
	{
		Instance = this;
	}

}