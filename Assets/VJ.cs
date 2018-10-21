using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine;
using UnityEngine.EventSystems;

public class VJ : MonoBehaviour {
	
	//------------playerControl----------------------
	public Rigidbody2D rigid2D;
	public Transform graphics;
	public float speed = 5.0f;
	private bool touchStart = false;
	private Vector2 pointA;
	private Vector2 pointB;

	public LayerMask whatIsGround;
	public Transform groundCheck;
	public bool grounded = false;
	public float jumpForce = 70f;
	public bool jumping = false;
	float groundRadius = 0.1f;
	//--------------VJ---------------------------
	public Transform circle;
	public Transform outerCircle;

	//-----------SpineAnimation----------------
	public SkeletonAnimation skeletonAnimation;

	void Start () {
		rigid2D.velocity = new Vector2(0, 0f);
	}
	
	
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			//pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
			pointA = new Vector2(-6.54f,-2.9f);

			circle.transform.position = pointA * 1;
			outerCircle.transform.position = pointA * 1;
			circle.GetComponent<SpriteRenderer>().enabled = true;
			outerCircle.GetComponent<SpriteRenderer>().enabled = true;		
		}
		
		if (Input.GetMouseButton(0))
		{
			touchStart = true;
			pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));

			skeletonAnimation.state.SetAnimation(1, "idle", true);
		}

		else
		{
			touchStart = false;
			skeletonAnimation.state.SetAnimation(0, "walk", true);
		}
		
	}

	
	void FixedUpdate() {
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
		if (touchStart)
		{
			Vector2 offset = pointB - pointA;
			Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
			moveCharacter(direction * 1);
			circle.transform.position = new Vector2(pointA.x + direction.x, pointA.y + direction.y) * 1;		
		}
		else {			
			/*circle.GetComponent<SpriteRenderer>().enabled = false;
			outerCircle.GetComponent<SpriteRenderer>().enabled = false;*/		
		}
	}

	void moveCharacter(Vector2 direction) {

		//direction.y = 0;		
		//player.Translate(direction * speed * Time.deltaTime);
		//rigid2D.MovePosition(rigid2D.position + Vector2.right * speed * Time.deltaTime);
		rigid2D.MovePosition(rigid2D.position + direction * speed * Time.deltaTime);

		if (direction.x > 0)
		{
			graphics.localRotation = Quaternion.Euler(0, 0, 0);
		}
		else if(direction.x < 0)
		{
			graphics.localRotation = Quaternion.Euler(0, 180, 0);
		}

	}

	//---------------------------------Jump----------------------------------
	public void jump()
	{
		Debug.Log("123");
		if (grounded)
		{
			rigid2D.AddForce(new Vector2(rigid2D.velocity.x, jumpForce), ForceMode2D.Impulse);

			skeletonAnimation.state.SetAnimation(0, "jump", false);
			skeletonAnimation.state.AddAnimation(0, "idle", true, 0);
			jumping = true;

		}
		else if ((!grounded && jumping))
		{
			Debug.Log("NOjump");
			jumping = false;
		}
	}
}
