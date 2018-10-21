using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree : MonoBehaviour {
	//gameData gamedata;
	public GameObject tree_CHOSSE;
	public GameObject tree_CHOSSE1;
	public GameObject tree_CHOSSE2;
	public GameObject tree_CHOSSE3;
	public GameObject tree_CHOSSE4;
	void Update () {
		if (gameData.T0 == 1) {
			tree_CHOSSE.SetActive (false);
		}
		if (gameData.T1 == 1) {
			tree_CHOSSE1.SetActive (false);
		}
		if (gameData.T2 == 1) {
			tree_CHOSSE2.SetActive (false);
		}
		if (gameData.T3 == 1) {
			tree_CHOSSE3.SetActive (false);
		}
		if (gameData.T4 == 1) {
			tree_CHOSSE4.SetActive (false);
		}

	}
}
