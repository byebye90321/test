using UnityEngine;
using System.Collections;

public class MovePlayers : MonoBehaviour {

	public Rigidbody2D rigid2D;
	public float speed = 5f;
	public VJHandler jsMovement;
	
	private Vector2 direction;
	//private float xMin,xMax,yMin,yMax;

	public LayerMask whatIsGround;
	public Transform groundCheck;
	float groundRadius = 0.1f;
	public bool grounded = false;
	public float jumpForce = 70f;
	public bool jumping = false;

	void Update () {
		
		direction = jsMovement.InputDirection; //InputDirection can be used as per the need of your project
		//player.Translate(direction * moveSpeed * Time.deltaTime);
		//direction.y = 0;
		rigid2D.MovePosition(rigid2D.position + direction * speed * Time.deltaTime);
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
		/*if(direction.magnitude != 0){
		
			transform.position += direction * moveSpeed;
			transform.position = new Vector3(Mathf.Clamp(transform.position.x,xMin,xMax),Mathf.Clamp(transform.position.y,yMin,yMax),0f);//to restric movement of player
		}	*/
	}	
	
	void Start(){
	
		//Initialization of boundaries
		/*xMax = Screen.width - 50; // I used 50 because the size of player is 100*100
		xMin = 50; 
		yMax = Screen.height - 50;
		yMin = 50;*/
	}

	public void jump()
	{
		Debug.Log("123");
		if (grounded)
		{
			rigid2D.AddForce(new Vector2(rigid2D.velocity.y, jumpForce), ForceMode2D.Impulse);
			jumping = true;

		}
		else if ((!grounded && jumping))
		{
			Debug.Log("NOjump");
			jumping = false;
		}
	}
}