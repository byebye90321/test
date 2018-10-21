using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraFollow : MonoBehaviour {

	public GameObject playerobj;

	[SerializeField]
	private float xMax;
	[SerializeField]
	private float yMax;
	[SerializeField]
	private float xMin;
	[SerializeField]
	private float yMin;

	public Transform target;
	public float smoothSpeed = 0.125f;
	public Vector3 offest;

	Vector3 velocity;

	void Start(){
		

	}

	void Update() {
		//transform.position = playerobj.transform.position;
		//transform.position = new Vector3(Mathf.Clamp(playerobj.transform.position.x,xMin+3f,xMax),Mathf.Clamp(playerobj.transform.position.y,yMin,yMax));

		/*Vector3 desiredPosition = target.position;
		Vector3 smoothedPosition = Vector2.Lerp(target.position, desiredPosition, smoothSpeed);
		smoothedPosition = new Vector2(Mathf.Clamp(playerobj.transform.position.x, xMin, xMax), Mathf.Clamp(playerobj.transform.position.y, yMin, yMax));
		transform.position = smoothedPosition;*/
		
		Vector3 newPosition = target.position + offest;
		//transform.position = new Vector2(Mathf.Clamp(transform.position.x, xMin, xMax), Mathf.Clamp(transform.position.y, yMin, yMax));
		transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothSpeed);

		if (transform.position.x < 0) {
			transform.position = new Vector2(Mathf.Clamp(transform.position.x, xMin, xMax), transform.position.y);
		}


	}
}