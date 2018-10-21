using UnityEngine;
using System.Collections;

public class control : MonoBehaviour
{
	//public GameObject cam1, cam2; //兩個不同的攝影機
	//public GameObject obj1, obj2; //兩個不同的GameObject

	public Transform target;
	public float smoothTime ;
	private Vector3 velocity = Vector3.zero;


	void Update()
	{
		// Define a target position above and behind the target transform
		Vector2 targetPosition = target.TransformPoint(new Vector2(0, 5));

		// Smoothly move the camera towards that target position
		transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
	}

}
