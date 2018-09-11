using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

public class NodeTemplateView : MonoBehaviour
{

	public NodeLibraryView Parent;
	public Text NameText;
	public Image ThumbnailImage;

	public Node Node;

	private void Awake()
	{
		NameText = transform.Find("NameText").GetComponent<Text>();
		ThumbnailImage = GetComponent<Image>();
		ThumbnailImage.OnPointerClickAsObservable().Subscribe(x => { OnPointerClick(); });
	}

	private void OnPointerClick()
	{
		UiMain.Instance.CurrentGraphView.AddNodeView(Node);
	}

}
