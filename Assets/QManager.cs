using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QManager : MonoBehaviour {
	public enum GameState {
		Start, Pause, Running, Dead, Fevertime, EnemyAppear, Win
	}
		
	public GameObject Q1;
	public GameObject Q2;
	public static GameState gameState;

	//public move movee;
	// Use this for initialization
	void Start () {
		Q1.SetActive(false);
		Q2.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Q1_OPEN()
	{
		Q1.SetActive(true);
		Time.timeScale = 0;
	}

	public void Q1_Close()
	{
		Time.timeScale = 1;
		gameState = GameState.Running;
		Q1.SetActive(false);
	}

	public void Q2_OPEN()
	{
		Q1.SetActive(true);
		Time.timeScale = 0;
	}

	public void Q2_Close()
	{
		Time.timeScale = 1;
		gameState = GameState.Running;
		Q1.SetActive(false);
	}


}
