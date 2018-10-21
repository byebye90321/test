using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sceneChange : MonoBehaviour {

	public void ToCollect() {
		SceneManager.LoadScene("collect");
	}

	public void ToMain()
	{
		SceneManager.LoadScene("main");
	}
}
