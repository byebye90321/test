using UnityEngine;
using System.Collections;

public class ToScene : MonoBehaviour {


	public void ToMain()
	{
		Application.LoadLevel(0);
	}

	public void ToIntro()
	{
		Application.LoadLevel(1);
	}

	public void ToCollect()
	{
		Application.LoadLevel(2);
	}

	public void ToSisterGame()
	{
		Application.LoadLevel(3);
	}

	public void ToBotherGame()
	{
		Application.LoadLevel(4);
	}

	public void ToSisterTree()
	{
		Application.LoadLevel(5);
	}


/*	void Start()
	{
		StartCoroutine(Example());

	}

	IEnumerator Example()
	{
		
		yield return new WaitForSeconds(3);
		Application.LoadLevel(1);
	}
*/
}