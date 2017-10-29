using UnityEngine;
using System.Collections;

public class Draggable : MonoBehaviour 
{
	public Transform _LeftLimit;
	public Transform _RightLimit;

	private Vector3 _StartScale;
	private float _PreviousMousePosition;
	private float _HorizontalMouseDelta;

	void Awake()
	{
		_StartScale = transform.localScale;
	}

	void OnMouseDown()
	{
		_PreviousMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
	}

	void OnMouseDrag()
	{
		UpdateHorizontalMouseDelta();
		UpdatePosition();
		UpdateFacing();
		ClampToLimits();
	}

	void ClampToLimits()
	{
		Vector3 pos = transform.position;

		if (pos.x < _LeftLimit.position.x)
		{
			pos.x = _LeftLimit.position.x;
		}

		if (pos.x > _RightLimit.position.x)
		{
			pos.x = _RightLimit.position.x;
		}

		transform.position = pos;
	}

	private void UpdateHorizontalMouseDelta()
	{
		_HorizontalMouseDelta = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - _PreviousMousePosition;

		_PreviousMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
	}

	public void UpdatePosition()
	{
		Vector3 pos = transform.position;

		pos.x += _HorizontalMouseDelta;

		transform.position = pos;
	}

	public void UpdateFacing()
	{
		if (_HorizontalMouseDelta < 0)
			transform.localScale = new Vector3(-_StartScale.x, _StartScale.y, _StartScale.z);

		if(_HorizontalMouseDelta > 0)
			transform.localScale = _StartScale;
	}
}