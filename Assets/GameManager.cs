using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public enum GameState
{


	Start, Pause, Running, Dead, Fevertime, EnemyAppear, Win
}


public class GameManager : MonoBehaviour
{

	public static GameManager Instance;
	public static GameState gameState;

	public int area;
	public int level;
	public int[,] area_level;

	public GameObject stopMenu;
	public GameObject consoleMenu;
	public GameObject WinMenu;
	public GameObject guideMenu;
	public Button Puase;
	public Button vecityButton;
	public Text Money;
	public Text ElementCount;
	public Text counter;
	public Text chest1;
	public Text chest2;
	public Text FinalChest1Text;
	public Text FinalChest2Text;

	AudioSource BackGrounaAudio;
	public AudioClip BackGroundSound;
	public AudioClip Dead_BGM;
	public AudioClip Enemy_BGM;
	public AudioClip Win_BGM;

	float StartTime = 1;
	public int ChestCount1 = 0;
	public int ChestCount2 = 0;
	public int money = 0;
	public float FeverTimeOver;



	// Use this for initialization
	void Start()
	{

		BackGrounaAudio = GetComponent<AudioSource>();

		//Puase.interactable = false;
		Time.timeScale = 1;
		gameState = GameState.Running;
		/*Instance = this;
		guideMenu.SetActive(true);
		stopMenu.SetActive(false);
		consoleMenu.SetActive(false);
		WinMenu.SetActive(false);

		area_level = new int[3, 3];
		*/
		InvokeRepeating("StartGame", 0, 1);
	}

	// Update is called once per frame
	void Update()
	{

	}

/*	public void ExitGuide()
	{
		guideMenu.SetActive(false);
		Time.timeScale = 1;
		InvokeRepeating("StartGame", 0, 1);
	}*/

	void StartGame()
	{
		StartTime -= 1;
		//counter.text = "" + StartTime;
		if (StartTime == 0)
		{
			gameState = GameState.Running;
			Puase.interactable = true;
			CancelInvoke();
			//RunningBGM();
			//counter.GetComponent<Text>().enabled = false;
		}
	}



	public void pause()
	{
		//gameState = GameState.Running;
		stopMenu.SetActive(true);
		// BackGrounaAudio.Stop();
		Time.timeScale = 0;
		gameState = GameState.Pause;

	}

	public void gamecontinue()
	{
		Time.timeScale = 1;
		gameState = GameState.Running;
		stopMenu.SetActive(false);
	}

	public void Reset()
	{

		StartCoroutine("WaitForAudio");
		Time.timeScale = 1;
		gameState = GameState.Running;
		stopMenu.SetActive(false);
	}

	public void Quit()
	{
		//      Application.Quit();
		Time.timeScale = 1;
		SceneManager.LoadScene("Search");

	}

	public void Dead()
	{
		if (gameState != GameState.Win)
		{
			//DeadBGM();
			gameState = GameState.Dead;
			consoleMenu.SetActive(true);

			/*if (player.Player.grounded)
			{

				StartCoroutine("GameOver");

			}*/


		}
	}

	public void win()
	{
		gameState = GameState.Win;
		StartCoroutine("Win");
		//ItemAmount.money += money;
		//PlayerPrefs.SetInt("money", ItemAmount.money);
		Element();

	}

	public void FeverTime()
	{
		//fevertime.FeverTime.Fevertime();

		gameState = GameState.Fevertime;
		vecityButton.interactable = false;
		StartCoroutine("DoSomeThingInDelay");

	}

	public void Chest()
	{

		chest1.text = "" + ChestCount1;
		chest2.text = "" + ChestCount2;

	}

	public void Element()
	{
		switch (level)
		{
			case 0:
				area_level[area, level] = Random.Range(1, 6);
				break;
			case 1:
				area_level[area, level] = Random.Range(6, 11);
				break;
			case 2:
				area_level[area, level] = Random.Range(11, 16);
				break;
		}
		ElementCount.text = "" + area_level[area, level];

		switch (area)
		{
			case 0:
				//ItemAmount.amountO += area_level[area, level];
				//PlayerPrefs.SetInt("element", ItemAmount.amountO);

				break;
			case 1:
				//ItemAmount.Light += area_level[area, level];
				//PlayerPrefs.SetInt("element", ItemAmount.Light);
				break;
			case 2:
				//ItemAmount.H2O += area_level[area, level];
				//PlayerPrefs.SetInt("element", ItemAmount.H2O);
				break;
		}



	}



	IEnumerator GameOver()
	{
		yield return new WaitForSeconds(1f);


		BackGrounaAudio.Stop();
		Time.timeScale = 0;
	}

	IEnumerator Win()
	{
		yield return new WaitForSeconds(1f);

		//WinBGM();
		WinMenu.SetActive(true);

		Money.text = "+" + money;
		FinalChest1Text.text = "" + ChestCount1;
		FinalChest2Text.text = "" + ChestCount2;
		Time.timeScale = 0;
	}

	IEnumerator DoSomeThingInDelay()
	{
		yield return new WaitForSeconds(FeverTimeOver);
		//fevertime.FeverTime.FeverTimeOver();
		gameState = GameState.Running;
		//player.Player.FeverTimeOver();
		vecityButton.interactable = true;
	}
	IEnumerator WaitForAudio()
	{
		yield return new WaitForSeconds(0.05f);
		SceneManager.LoadScene(Application.loadedLevel);
	}
	//--------------------BGM----------------------------
	/*public void RunningBGM()
	{
		BackGrounaAudio.clip = BackGroundSound;
		BackGrounaAudio.loop = true;
		BackGrounaAudio.Play();
		// AudioFadeIn();
		InvokeRepeating("AudioFadeIn", 0, 0.5f);
	}
	public void DeadBGM()
	{
		BackGrounaAudio.Stop();
		BackGrounaAudio.clip = Dead_BGM;
		BackGrounaAudio.loop = false;
		BackGrounaAudio.Play();


	}
	public void WinBGM()
	{
		BackGrounaAudio.Stop();
		BackGrounaAudio.clip = Win_BGM;
		BackGrounaAudio.loop = false;
		BackGrounaAudio.Play();

	}
	public void EnemyAppearBGM()
	{
		BackGrounaAudio.Stop();
		BackGrounaAudio.volume = 0.2f;
		BackGrounaAudio.clip = Enemy_BGM;
		BackGrounaAudio.loop = true;
		BackGrounaAudio.Play();
		InvokeRepeating("AudioFadeIn", 0, 0.1f);
	}
	public void EnemyRunOutBGM()
	{


		InvokeRepeating("AudioFadeOut", 0, 0.1f);

	}

	void AudioFadeIn()
	{
		BackGrounaAudio.volume += 0.2f;
		if (BackGrounaAudio.volume >= 1)
		{
			BackGrounaAudio.volume = 1;
			CancelInvoke();
		}
	}

	void AudioFadeOut()
	{
		BackGrounaAudio.volume -= 0.2f;
		if (BackGrounaAudio.volume <= 0.3f)
		{
			BackGrounaAudio.volume = 0.3f;
			BackGrounaAudio.Stop();
			BackGrounaAudio.volume = 0.3f;
			BackGrounaAudio.clip = BackGroundSound;
			BackGrounaAudio.loop = true;
			BackGrounaAudio.Play();
			CancelInvoke();
			InvokeRepeating("AudioFadeIn", 0, 0.1f);
		}
	}
	*/

}
