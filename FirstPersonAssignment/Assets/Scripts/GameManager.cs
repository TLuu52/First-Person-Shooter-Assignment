using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{

	// make game manager public static so can access this from other scripts
	public static GameManager gm;

	// public variables
	public int score = 0;

	public bool canBeatLevel = false;
	public int beatLevelScore = 0;

	public float startTime = 5.0f;

	public Text mainScoreDisplay;
	public Text mainTimerDisplay;

	public GameObject gameOverScoreOutline;

	public AudioSource musicAudioSource;

	public bool gameIsOver = false;

	public GameObject playAgainButtons;
	public string playAgainLevelToLoad;

	public GameObject nextLevelButtons;
	public string nextLevelToLoad;

	private float currentTime;

	public string currentWeapon; // Weapon pickups
	public GameObject Rifle;
	public GameObject Pistol;
	public GameObject MachineGun;

	public float magazine;
	public float ammoCurrent;
	public float ammoTotal;

	public Material darkMode;
	public Material lightMode;

	public GameObject menu;
	public int menuFlag;
	public GameObject mouse; // set to whatever MouseLooker script is in

	// setup the game
	void Start()
	{

		// set the current time to the startTime specified
		currentTime = startTime;

		// get a reference to the GameManager component for use by other scripts
		if (gm == null)
			gm = this.gameObject.GetComponent<GameManager>();

		// init scoreboard to 0
		mainScoreDisplay.text = "0";

		// inactivate the gameOverScoreOutline gameObject, if it is set
		if (gameOverScoreOutline)
			gameOverScoreOutline.SetActive(false);

		// inactivate the playAgainButtons gameObject, if it is set
		if (playAgainButtons)
			playAgainButtons.SetActive(false);

		// inactivate the nextLevelButtons gameObject, if it is set
		if (nextLevelButtons)
			nextLevelButtons.SetActive(false);

		currentWeapon = "Rifle";
		spawnWeapon();
		ammoTotal = 100;
		menuFlag = 0;
		menu.SetActive(false);
	}

	// this is the main game event loop
	void Update()
	{
		if (!gameIsOver)
		{
			if (canBeatLevel && (score >= beatLevelScore))
			{  // check to see if beat game
				BeatLevel();
			}
			else if (currentTime < 0)
			{ // check to see if timer has run out
				EndGame();
			}
			else
			{ // game playing state, so update the timer
				currentTime -= Time.deltaTime;
				mainTimerDisplay.text = currentTime.ToString("0.00");
			}
		}

		if (Input.GetKeyDown("m"))
		{
			if (menuFlag == 0)
			{
				// turn the menu on
				menu.SetActive(true);
				mouse.gameObject.GetComponent<MouseLooker>().LockCursor(false);
				mouse.gameObject.GetComponent<MouseLooker>().trackMouse = false;
				menuFlag = 1;
			}

			else
			if (menuFlag == 1)
			{
				// turn the menu off
				menu.SetActive(false);
				mouse.gameObject.GetComponent<MouseLooker>().LockCursor(true);
				mouse.gameObject.GetComponent<MouseLooker>().trackMouse = true;
				menuFlag = 0;
			}
		}

	}

	void EndGame()
	{
		// game is over
		gameIsOver = true;

		// repurpose the timer to display a message to the player
		mainTimerDisplay.text = "GAME OVER";

		// activate the gameOverScoreOutline gameObject, if it is set 
		if (gameOverScoreOutline)
			gameOverScoreOutline.SetActive(true);

		// activate the playAgainButtons gameObject, if it is set 
		if (playAgainButtons)
			playAgainButtons.SetActive(true);

		// reduce the pitch of the background music, if it is set 
		if (musicAudioSource)
			musicAudioSource.pitch = 0.5f; // slow down the music
	}

	void BeatLevel()
	{
		// game is over
		gameIsOver = true;

		// repurpose the timer to display a message to the player
		mainTimerDisplay.text = "LEVEL COMPLETE";

		// activate the gameOverScoreOutline gameObject, if it is set 
		if (gameOverScoreOutline)
			gameOverScoreOutline.SetActive(true);

		// activate the nextLevelButtons gameObject, if it is set 
		if (nextLevelButtons)
			nextLevelButtons.SetActive(true);

		// reduce the pitch of the background music, if it is set 
		if (musicAudioSource)
			musicAudioSource.pitch = 0.5f; // slow down the music
	}

	// public function that can be called to update the score or time
	public void targetHit(int scoreAmount, float timeAmount)
	{
		// increase the score by the scoreAmount and update the text UI
		score += scoreAmount;
		mainScoreDisplay.text = score.ToString();

		// increase the time by the timeAmount
		currentTime += timeAmount;

		// don't let it go negative
		if (currentTime < 0)
			currentTime = 0.0f;

		// update the text UI
		mainTimerDisplay.text = currentTime.ToString("0.00");
	}

	// public function that can be called to restart the game
	public void RestartGame()
	{
		// we are just loading a scene (or reloading this scene)
		// which is an easy way to restart the level
		SceneManager.LoadScene(playAgainLevelToLoad);
	}

	// public function that can be called to go to the next level of the game
	public void NextLevel()
	{
		// we are just loading the specified next level (scene)
		SceneManager.LoadScene(nextLevelToLoad);
	}

	public void spawnWeapon()
	{
		switch (currentWeapon)
		{
			case "Rifle":
				Rifle.SetActive(true);
				Pistol.SetActive(false);
				MachineGun.SetActive(false);
				magazine = 15f;
				ammoCurrent = 15f;
				break;
			case "Pistol":
				Pistol.SetActive(true);
				Rifle.SetActive(false);
				MachineGun.SetActive(false);
				magazine = 5f;
				ammoCurrent = 5f;
				break;
			case "MachineGun":
				MachineGun.SetActive(true);
				Pistol.SetActive(false);
				Rifle.SetActive(false);
				magazine = 50;
				ammoCurrent = 50f;
				break;
		}
	}

	public void changeLightMode()
	{
		RenderSettings.skybox = lightMode;
	}

	public void changeDarkMode()
	{
		RenderSettings.skybox = darkMode;
	}

	public void changeGun1()
	{
		currentWeapon = "Rifle";
		spawnWeapon();
	}

	public void changeGun2()
	{
		currentWeapon = "Pistol";
		spawnWeapon();
	}

	public void changeGun3()
	{
		currentWeapon = "MachineGun";
		spawnWeapon();
	}

}