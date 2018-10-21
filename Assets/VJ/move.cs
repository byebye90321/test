using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class move : MonoBehaviour {

	public float moveForce = 5;
	//public float boostMultiplier = 2;
	public Rigidbody2D rigid2D;

	/*public LayerMask whatIsGround;
	public Transform groundCheck;
	public bool grounded = false;
	public float jumpForce = 70f;
	public bool jumping = false;
	float groundRadius = 0.1f;*/

	public 
	void Start () {
		rigid2D = this.GetComponent<Rigidbody2D>();
	}

	public void Update() {
		//grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

		/*if (grounded)
		{
			RunAnimation();
		}

		else if (!grounded && count == 1)
		{
			JumpAnimation();
		}*/
	}

	void FixedUpdate() {
		Vector2 moveVec = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertiacl")) * moveForce;
		//bool isBoosting = CrossPlatformInputManager.GetButton("Boost");
		
		//myBody.AddForce(moveVec * (isBoodting ? boostMultiplier : 1));
		rigid2D.MovePosition(rigid2D.position + moveVec * moveForce * Time.deltaTime);
	}

	/*public void jump()
	{
		Debug.Log("123");
		if (grounded)
		{
			rigid2D.AddForce(new Vector2(rigid2D.velocity.x, jumpForce), ForceMode2D.Impulse);
			jumping = true;
		}
		else if ((!grounded && jumping))
		{
			Debug.Log("NOjump");
			jumping = false;
		}
		else if(!grounded && !jumping)
		{
			jumping = false;
		}
	}*/
}
