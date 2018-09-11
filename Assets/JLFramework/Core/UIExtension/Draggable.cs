using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour
{

	private CanvasGroup _group;
	private float _offsetY;
	private float _offsetX;

	public bool ChangeOpacity = true;

	public float DraggedOpacity = 0.7f;

	public void OnBeginDrag(BaseEventData eventData)
	{
		_offsetX = transform.position.x - Input.mousePosition.x;
		_offsetY = transform.position.y - Input.mousePosition.y;

		if (_group != null)
			_group.alpha = DraggedOpacity;
	}

	public void OnDrag(BaseEventData eventData)
	{
		transform.position = new Vector3(_offsetX + Input.mousePosition.x, _offsetY + Input.mousePosition.y);
	}

	public void OnEndDrag(BaseEventData eventData)
	{
		if (_group != null)
			_group.alpha = 1f;
	}

	private void Awake()
	{
		_group = GetComponent<CanvasGroup>();
	}
}