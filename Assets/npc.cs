using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class npc : MonoBehaviour
{
    
	public Transform target;
	public Transform Q1;
	public Transform Q2;
	public Transform Win;
	private int isQQ=0;
    public float QRange;
	private bool butt1;
	private bool butt2;
	private bool butt3;
	private bool butt4;

    private float distanceToTarget;
	public GameObject Q1C; 
	public GameObject Q2C; 
    public BoxCollider2D Q11;
    public BoxCollider2D Q22;
	public control control;

    public void Update()
	{
        
      
//-------------------------------------------------------遇到Q1
		float Q1distanceToTarget = Mathf.Abs (Q1.position.x - target.position.x);
		//Debug.Log (Q1distanceToTarget);
		if (Q1distanceToTarget < QRange && isQQ == 0) {   

			//Time.timeScale = 0;
			//Q1C.SetActive (true);
			isQQ += 1;
			gameData.T0 = 1;
			GameObject.Find ("Camera1").GetComponent<CameraFollow> ().enabled = false; 
			GameObject.Find ("Camera1").GetComponent<control> ().enabled = true; 
			//control.cameraMove ();
			Debug.Log("77");
		}
		/*
//-------------------------------------------------------遇到Q2
		float Q2distanceToTarget = Mathf.Abs (Q2.position.x - target.position.x);
		//Debug.Log (Q1distanceToTarget);
		if (Q2distanceToTarget < QRange && isQQ == 1) {   

			Time.timeScale = 0;
			Q2C.SetActive (true);
			isQQ += 1;
		}

//-------------------------------------------------------遇到Win
		float WindistanceToTarget = Mathf.Abs (Win.position.x - target.position.x);
		//Debug.Log (Q1distanceToTarget);
		if (WindistanceToTarget < QRange && isQQ == 2) {   

			Application.LoadLevel(5);
		}

	}

	




    public void but1(){
		butt1=false;
		butt2=false;
		Q1C.SetActive (false);
		Q11.GetComponent<Collider2D>().enabled = false;
		Time.timeScale = 1;
		gameData.T1 = 1;
	}

	public void but2(){
		butt1=false;
		butt2=false;
		Q1C.SetActive (false);
		Q11.GetComponent<Collider2D>().enabled = false;
		Time.timeScale = 1;
		gameData.T2 = 1;
	}
	public void but3(){
		butt3=false;
		butt4=false;
		Q2C.SetActive (false);
		Q22.GetComponent<Collider2D>().enabled = false;
		Time.timeScale = 1;
		gameData.T3 = 1;
	}
	public void but4(){
		butt3=false;
		butt4=false;
		Q2C.SetActive (false);
		Q22.GetComponent<Collider2D>().enabled = false;
		Time.timeScale = 1;
		gameData.T4 = 1;
	}
*/


		
	}
}

