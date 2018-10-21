using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraFollow123 : MonoBehaviour {

	GameObject playerobj;
	float player;

	[SerializeField]
	private float xMax;
	[SerializeField]
	private float yMax;
	[SerializeField]
	private float xMin;
	[SerializeField]
	private float yMin;


	void Start(){
		playerobj = GameObject.Find ("Player");


	}

	void Update(){

	//	transform.position = playerobj.transform.position;

	//	transform.position = new Vector3 (Mathf.Clamp(playerobj.transform.position.x,xMin,xMax),Mathf.Clamp(playerobj.transform.position.y,yMin,yMax),0);
		transform.position = new Vector3 (Mathf.Clamp(playerobj.transform.position.x,xMin,xMax),Mathf.Clamp(playerobj.transform.position.y,yMin,yMax));


	}
}