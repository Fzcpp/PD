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
			Parameter.Value.Subscribe(x => { Value = (int)x; });
		}

		private void Update()
		{
			if (Value != (int)Parameter.Value.Value)
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