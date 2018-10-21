using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour {
	public enum GameState {
		Start, Pause, Running, Dead, Fevertime, EnemyAppear, Win
	}
		
	public GameObject characher_choose;
	public static GameState gameState;

	//public move movee;
	// Use this for initialization
	void Start () {
		characher_choose.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void characher_Choose()
	{
		characher_choose.SetActive(true);
		//Time.timeScale = 0;
	}

	public void character_Close()
	{
		Time.timeScale = 1;
		gameState = GameState.Running;
		characher_choose.SetActive(false);
	}


}
