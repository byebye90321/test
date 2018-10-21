using UnityEngine;
using System.Collections;

public class drag : MonoBehaviour
{

	void OnMouseDrag()
	{
		Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

		transform.position = objPosition;
	}
}