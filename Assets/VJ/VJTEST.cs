using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spine.Unity;
using Spine;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;

public class VJTEST : MonoBehaviour
{

	//------------playerControl----------------------
	public Rigidbody2D rigid2D;
	public Transform graphics;
	public float speed = 5.0f;
	private bool touchStart = false;
	private Vector2 pointA;
	private Vector2 pointB;
	public Button Active;

	public LayerMask whatIsGround;
	public Transform groundCheck;
	float groundRadius = 0.1f;
	public bool grounded = false;
	public float jumpForce = 70f;
	bool jumping = false;
	float dirX;


	//--------------VJ---------------------------
	public Transform circle;
	public Transform outerCircle;

	//-----------SpineAnimation----------------
	public Animator animator;

	//------------NPC Obstacle----------------
	public GameObject particle;

	void Start()
	{
		rigid2D.velocity = new Vector2(0, 0f);
		Active.interactable = false;
	}

	/*public void OnDrag(BaseEventData ped)
	{
		//pointA = new Vector2(-6f,-3f);
		pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));	
		/*circle.GetComponent<SpriteRenderer>().enabled = true;
		outerCircle.GetComponent<SpriteRenderer>().enabled = true;*/


	/*public void OnPointerDown(BaseEventData ped)
	{
		//pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
		pointA = new Vector2(-6.5f, -3f);
		circle.transform.position = pointA * 1;
		outerCircle.transform.position = pointA * 1;
		touchStart = true;
	}

	public void OnPointerUp(BaseEventData ped)
	{
		touchStart = false;
		pointA = new Vector2(-6f, -3f);
		skeletonAnimation.state.SetAnimation(1, "idle", true);
	}

	void FixedUpdate()
	{
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

		if (touchStart)
		{
			Vector2 offset = pointB - pointA;
			Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
			moveCharacter(direction * 1);
			circle.transform.position = new Vector2(pointA.x + direction.x, pointA.y + direction.y) * 1;

		}
		else
		{
			skeletonAnimation.state.SetAnimation(1, "run", true);
			//skeletonAnimation.state.SetAnimation(1, "walk", true);
			/*circle.GetComponent<SpriteRenderer>().enabled = false;
			outerCircle.GetComponent<SpriteRenderer>().enabled = false;
		}
	}*/

	/*void moveCharacter(Vector2 direction)
	{
		skeletonAnimation.state.SetAnimation(1, "walk", true);
		//direction.y = 0;
		//player.Translate(direction * speed * Time.deltaTime);
		rigid2D.MovePosition(rigid2D.position + direction * speed * Time.deltaTime);

		if (direction.x > 0)
		{
			graphics.localRotation = Quaternion.Euler(0, 0, 0);
		}
		else if (direction.x < 0)
		{
			graphics.localRotation = Quaternion.Euler(0, 180, 0);
		}

	}*/

	/*public void Update() {
	 * //fixedUpdate內容
		//bool isBoosting = CrossPlatformInputManager.GetButton("Boost");
		//rigid2D.AddForce(moveVec);
		//rigid2D.MovePosition(rigid2D.position + moveVec * speed * Time.deltaTime);
	}*/


	public void FixedUpdate()
	{
		//-------------JUMP-----------------------------
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

		//-------------MOVE----------------------------

		Vector2 moveVec = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertiacl")) * speed;
		rigid2D.velocity = new Vector2(moveVec.x, rigid2D.velocity.y);
		animator.SetFloat("Speed", Mathf.Abs(moveVec.x));

		if (grounded)
		{
			if (CrossPlatformInputManager.GetButtonDown("Jump"))
			{
				jumping = true;
				rigid2D.velocity = new Vector2(0, jumpForce);
				animator.SetBool("isJump", true);
			}
		}
		else {
			OnLanding();
		}
		

		if (moveVec.x > 0)
		{
			graphics.localRotation = Quaternion.Euler(0, 0, 0);
		}
		else if (moveVec.x < 0)
		{
			graphics.localRotation = Quaternion.Euler(0, 180, 0);
		}

		
	}

	public void OnLanding() {
		animator.SetBool("isJump", false);
		jumping = false;
	}


	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.name == "flower")
		{
			particle.SetActive(true);
			Active.interactable = true;
		}
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		if (coll.gameObject.name == "flower")
		{
			particle.SetActive(false);
			Active.interactable = false;
		}
	}

	/*if (Mathf.Abs(moveVec.x) > 0 && CrossPlatformInputManager.GetButtonDown("Jump"))
	{
		jump();
	}
	else if (Mathf.Abs(moveVec.x) > 0 && !CrossPlatformInputManager.GetButtonDown("Jump"))
	{
		move();
	}
	else
	{
		//skeletonAnimation.state.SetAnimation(1, "walk", true);
	}	*/




	/*public void move()
	{	
		dirX = CrossPlatformInputManager.GetAxis("Horizontal");

		if(dirX > 0)
		{
			//skeletonAnimation.state.SetAnimation(0, "idle", true);
			graphics.localRotation = Quaternion.Euler(0, 0, 0);
		}
		else if (dirX < 0)
		{
			//skeletonAnimation.state.SetAnimation(0, "idle", true);
			graphics.localRotation = Quaternion.Euler(0, 180, 0);
		}

	}

	public void jump()
	{
		if (grounded)
		{
			jumping = true;
			rigid2D.velocity = new Vector2(0, jumpForce);
			//skeletonAnimation.state.SetAnimation(0, "jump_RE", false);
		}
		else if (!grounded && jumping)
		{
			jumping = false;
			Debug.Log("NOjump");
		}
	}*/

}

