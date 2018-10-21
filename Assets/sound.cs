using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class sound : MonoBehaviour {


	public Slider musicSlider;
	public Slider sfxSlider;

	public AudioSource Bgm;
	private float BgmVolume;

	// Use this for initialization
	void Start () {

		//test
		//musicBtn = GameObject.Find("musicBtn").GetComponent<Button>();
		//sfxBtn = GameObject.Find("sfxBtn").GetComponent<Button>();
		Bgm = GameObject.Find("music").GetComponent<AudioSource>();


		///原本的
		/*musicBtn.GetComponent<Button>();
		sfxBtn = sfxBtn.GetComponent<Button>();*/
		//Bgm = GetComponent<AudioSource>();

		BgmVolume = PlayerPrefs.GetFloat("StaticVolume.bgmVolume", StaticVolume.bgmVolume);

		musicSlider.value = BgmVolume;
		Bgm.volume = BgmVolume;
		Debug.Log(BgmVolume);

	}
	

	// Update is called once per frame
	void Update () {
		BgmVolume = PlayerPrefs.GetFloat("StaticVolume.bgmVolume", StaticVolume.bgmVolume);
	}

	//Music開關
/*	public void musicOnOff()
	{
		counterMusic++;
		if (counterMusic % 2 == 0)
		{
			//musicBtn.image.overrideSprite = Off;
			Bgm.volume = 0;
			musicSlider.value = 0;
			Bgm.volume = BgmVolume;
			
		}
		else
		{
			//musicBtn.image.overrideSprite = On;
			Bgm.volume = 0.5f;
			musicSlider.value = 0.5f;
			Bgm.volume = BgmVolume;
		}
	}

	//Sfx開關
	public void sfxOnOff()
	{
		counterSfx++;
		if (counterSfx % 2 == 0)
		{
			//sfxBtn.image.overrideSprite = Off;
			
		}
		else
		{
			//sfxBtn.image.overrideSprite = On;
		}
	}
	*/

	//music音量
	public void Music_volume()
	{
		Bgm.volume = musicSlider.value;
		
		BgmVolume = Bgm.volume;
		StaticVolume.bgmVolume= BgmVolume;
		PlayerPrefs.SetFloat("StaticVolume.bgmVolume", BgmVolume);
		//Bgm.volume = PlayerPrefs.GetFloat("StaticVolume.bgmVolume", StaticVolume.bgmVolume);

		Debug.Log(BgmVolume);
		//Debug.Log(StaticVolume.bgmVolume);

	/*	if (musicSlider.value == 0)
		{
			musicBtn.image.overrideSprite = Off;
		}
		else {
			musicBtn.image.overrideSprite = On;
		}
		*/
	}
}
