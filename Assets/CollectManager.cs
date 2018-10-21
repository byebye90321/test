using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectManager : MonoBehaviour {
	public enum GameState {
		Start, Pause, Running, Dead, Fevertime, EnemyAppear, Win
	}
		
	public GameObject tree_choose;
	public static GameState gameState;

	//public move movee;
	// Use this for initialization
	void Start () {
		tree_choose.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void tree_Choose()
	{
		tree_choose.SetActive(true);
		//Time.timeScale = 0;
	}

	public void tree_Close()
	{
		Time.timeScale = 1;
		gameState = GameState.Running;
		tree_choose.SetActive(false);
	}


}
