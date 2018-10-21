using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour {

	public static HP hp;

	public float MaxHP;
	public float Hp;
	public float SpendHP; //每秒扣體
	//public float seed; //回體
	public Slider slider;
	public Image sliderimage;
	float r = 1, g = 0.5801887f, b = 0.716952f;  //原平衡條粉色
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Hp -= Time.deltaTime * SpendHP;
		slider.value = Hp;

		if (slider.value < 50) {
			//sliderimage.color = Color.Lerp(zeroColor, fullColor, slider.value / 5);  //從G變R
			sliderimage.color = Color.Lerp(Color.red, new Color(r, g, b), slider.value / 50);  //從G變R
		}
	}
}
