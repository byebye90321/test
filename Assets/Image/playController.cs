using UnityEngine;
using System.Collections;
using Spine.Unity;
using Spine;
public class playController : MonoBehaviour {
	public static playController Player;

//	Animator anim;
	Rigidbody2D rigi;
/*	AudioSource audio;
	public GameObject TriggerTrap;
	public GameObject FeverTime;*/
	public GameObject hurt;

	//-----------------------ground check------------------------
	public LayerMask whatIsGround;
	public bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.1f;
	//-----------------------Player Control----------------------
	public float jumpForce = 70f;
	public float speed ;
	//2段跳
	//public float jumpForce2 = 10f;
	bool jumping = false;
	private float count = 1;


	public float hurtSpeed;
	//--------------------------velocity-------------------------
	//	bool pressdown=false;
	//	public float Vecity = 0.001f;
		public float stop;
		public float VecitySpeed;
		public float MaxSpeed = 0.8f;
		//---------------------------Hurt-----------------------------
		public float VecityHurt;
		public float RecoverySpeed;
		//------------------------FeverTime---------------------------
	/*	public float FeverSpeed;
		public float AnimFeverTime;
		//-------------------------vecity animation-------------------
		public float AnimMaxrunSpeed=5f;
		public float AnimVecity = 0.001f;
		public float AnimStop;
		//--------------------------sound-----------------------------
		public AudioClip JumpSound;*/

	//--------------------------Animation-------------------------
	[SpineAnimation]
	public string jumpAnim;
	[SpineAnimation]
	public string runAnim;

	private SkeletonAnimation skeletonAnimation;

	// Use this for initialization
	void Start()
	{
		Player = this;

		rigi = GetComponent<Rigidbody2D>();
		//audio = GetComponent<AudioSource>();
		rigi.AddForce(new Vector2(0, 0));
		rigi.velocity = new Vector2(0, 0f);
		VecitySpeed = speed;
		//rend = GetComponent<SpriteRenderer>();
		skeletonAnimation = GetComponent<SkeletonAnimation>();
		skeletonAnimation.state.SetAnimation(0, "run", true);  //(起始偵,動畫名,loop)
	}

	// Update is called once per frame
	void Update()
	{


		if (GameManager.gameState == GameState.Running)
		{
			grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);


			//skeletonAnimation.state.SetAnimation(0, "run", true);
			Player.transform.position = new Vector3(Player.transform.position.x + VecitySpeed, Player.transform.position.y, 10);
			grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);



			if (VecitySpeed < speed)
			{
				VecitySpeed += RecoverySpeed;

				if (VecitySpeed < 0)
				{
					VecitySpeed = 0.02f;
				}

				if (VecitySpeed >= speed)
				{
					VecitySpeed = speed;
				}
				rigi.velocity = new Vector2(Time.deltaTime * VecitySpeed, rigi.velocity.y);
			}
			rigi.velocity = new Vector2(Time.deltaTime * VecitySpeed, rigi.velocity.y);



			if (grounded)
			{
				//skeletonAnimation.state.SetAnimation(0, runAnim, true);
				//skeletonAnimation.AnimationName = "run";
				//skeletonAnimation.loop = true;
				
			}
			else if (!grounded)
			{
				/*skeletonAnimation.state.SetAnimation(0, jumpAnim, false);
				skeletonAnimation.state.AddAnimation(0, "run", true, 0);*/
			}
			Debug.Log(skeletonAnimation.AnimationName);
		}
	}

	//---------------------------------Jump & Double Jump----------------------------------
	public void jump()
	{
		if (grounded)
		{
			rigi.AddForce(new Vector2(rigi.velocity.x, jumpForce), ForceMode2D.Impulse);

			skeletonAnimation.state.SetAnimation(0, jumpAnim, false);
			skeletonAnimation.state.AddAnimation(0, "run", true, 0);

			jumping = true;
			Debug.Log("jump");

		}
		else if ((!grounded && jumping))
		{
			Debug.Log("NOjump");
			jumping = false;

		}

		else if (!grounded && count == 0 && !jumping)
		{
			rigi.velocity = new Vector2(rigi.velocity.x, 0f);
			Debug.Log("NONOjump");
		}
	}
	float r = 0.9245283f, g = 0.3968494f, b = 0.3968494f, a = 1f;

	public void Hurt()
	{
		VecitySpeed -= VecityHurt;

			//yield return new WaitForSeconds(1f); // Wait 1 second.
			StartCoroutine(DoSomeThingInDelay()); // Flash the fill color.
		

		//skeletonAnimation.skeleton.SetColor(new Color(r,g,b,a));
		/*StartCoroutine("DoSomeThingInDelay");
		Debug.Log("666");*/
	}


	IEnumerator DoSomeThingInDelay()
	{
		yield return new WaitForSeconds(0.5f);
		skeletonAnimation.skeleton.SetColor(Color.white);

		}

	}



