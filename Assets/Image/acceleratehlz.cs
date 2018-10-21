using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class acceleratehlz : MonoBehaviour
{
	//public float speed = 10.0F;

	public float spriteOffset;
	Vector3 initialPosition;
	Vector3 newPosition;

	private void Start()
	{
		initialPosition = transform.position;
	}


	void Update()
	{
		//Vector3 dir = Vector3.zero;
		//dir.y = Input.acceleration.y;
		//dir.x = Input.acceleration.x;

		//if (dir.sqrMagnitude > 1)
		//	dir.Normalize();

		//dir *= Time.deltaTime;
		//transform.Translate(dir * speed);

		transform.position = new Vector3 ((initialPosition.x + (spriteOffset * Input.acceleration.x))*Time.deltaTime, (initialPosition.y + (spriteOffset * Input.acceleration.y))*Time.deltaTime, initialPosition.z);
	
	}


		
}
