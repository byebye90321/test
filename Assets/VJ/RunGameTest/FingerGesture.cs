using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class FingerGesture : MonoBehaviour
{
	private Vector2 pointA;
	private Vector2 pointB;

	public bool Touch;

	public Animator anim;
	public Rigidbody2D rigid2D;
	public float jumpForce = 70f;
	public void Update()
	{

		if (Input.GetMouseButtonUp(0))
		{
			pointB = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
			Touch = true;
		}
		else {
			Touch = false;
		}
	
		if (Input.GetMouseButtonDown(0))
		{
			pointA = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
		}

	}

	private void FixedUpdate() {

		if (Touch)
		{
			Vector2 offset = pointB - pointA;

			Debug.Log("A : " + pointA);
			Debug.Log("B : " + pointB);

			if (offset.y > 0)
			{
				Debug.Log("up");
				anim.SetTrigger("jump");
				rigid2D.velocity = new Vector2(0, jumpForce);
			}
			else if(offset.y<0){
				Debug.Log("down");
				anim.SetTrigger("crouch");
			}
		}
	}

	
}