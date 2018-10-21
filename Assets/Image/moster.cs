using UnityEngine;
using System.Collections;

public class moster : MonoBehaviour {
	public static moster Moster;

	Rigidbody2D rigi;
	public float speed;

	void Start()
	{
		Moster = this;

		rigi = GetComponent<Rigidbody2D>();
		//audio = GetComponent<AudioSource>();
		rigi.AddForce(new Vector2(0, 0));
		rigi.velocity = new Vector2(0, 0f);


		//rend = GetComponent<SpriteRenderer>();

	}

	// Update is called once per frame
	void Update()
	{
		if (GameManager.gameState == GameState.Running)
		{
			//grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
			Moster.transform.position = new Vector3(Moster.transform.position.x + speed, Moster.transform.position.y, 10);
		}

	}

	public void Hurt()
	{
		speed -= 0.002f;
		//anim.SetLayerWeight(1, 1f);
		StartCoroutine("DoSomeThingInDelay");
	}
	IEnumerator DoSomeThingInDelay()
	{
		yield return new WaitForSeconds(1);
		//anim.SetLayerWeight(1, 0f);
	}






}
