using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiMain : MonoBehaviour
{

	public static UiMain Instance;

	public NodeLibraryView NodeLibraryView;

	public GraphView GraphView;

	void Awake()
	{
		Instance = this;
	}

}