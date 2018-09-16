using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace JL
{

	public class ParameterView : MonoBehaviour
	{

		public NodeView NodeView;

		public int Value;

		public string Name;

		public Image LeftPoint;

		public Image RightPoint;

		public Parameter Parameter;

		private void Awake()
		{
			Parameter = NodeView.Node.Parameters[Name];
			Parameter.Value.Value = Value;
			Parameter.Value.Subscribe(x =>
			{
				Debug.Log("ValueChanged: " + x + "  " + x.GetType());
				try
				{
					Value = int.Parse(x.ToString());
				}
				catch(Exception e)
				{
					Debug.Log(e);
					return;
				}
				//Value = int.Parse((string)x);
			});
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				Parameter.Value.Value = Value;
			}
		}

		public void OnLeftPointClicked()
		{
			Debug.Log("OnLeftPointtClicked");
			if (UiMain.Instance.CurrentSource != null)
			{
				Debug.Log("参数连接成功");
				Parameter.SetSource(UiMain.Instance.CurrentSource);
				UiMain.Instance.CurrentSource = null;
			}
			else
			{
				Debug.Log("参数连接失败");
			}
		}

		public void OnRightPointClicked()
		{
			Debug.Log("OnRightPointClicked");
			UiMain.Instance.CurrentSource = Parameter;
		}

	}

}