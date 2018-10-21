using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurt : MonoBehaviour {
	public static Hurt hurt;
	// Use this for initialization
	void Start () {
		hurt = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "object")
		{
			//HurtAudio.PlayOneShot(HurtBGM, 0.8f);
			//            player.Player.Hurt();
			//HP.hp.Hurt();
			//fevertime.FeverTime.Hurt();
			playController.Player.Hurt();
			//BGspeedHurt = true;
			Debug.Log("hurt");
			StartCoroutine("DoSomeThingInDelay");


		}
	}

	IEnumerator DoSomeThingInDelay()
	{
		yield return new WaitForSeconds(2f);
		//BGspeedHurt = false;
	}
}
