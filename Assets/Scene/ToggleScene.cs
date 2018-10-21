using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleScene : MonoBehaviour
{

	public Canvas graphic;
	public Toggle high;
	public Toggle low;

	// Use this for initialization
	void Start()
	{
		graphic = graphic.GetComponent<Canvas>();
		//high = high.GetComponent<Toggle>();
		//low = low.GetComponent<Toggle>();
		//graphic.enabled = false;

	}

	// Update is called once per frame
	void Update()
	{

	}


	public void highGraphic() {
		QualitySettings.SetQualityLevel(3);//fantastic
		Debug.Log("high");
	}
	public void lowGraphic()
	{
		QualitySettings.SetQualityLevel(1);//fast
		Debug.Log("low");
	}


}
