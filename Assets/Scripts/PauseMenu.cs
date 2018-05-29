using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	public string mainMenuScene;
	public GameObject menu;
	public bool isPaused;
	public Slider volumeSlider;

	// Use this for initialization
	void Start () {
		volumeSlider.value = PlayerPrefs.GetFloat ("Volume");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (isPaused) {
				ResumeGame ();
			} else {
				isPaused = true;
				menu.SetActive (true);
				Time.timeScale = 0f;
			}
		}
	}

	public void ResumeGame() {
		isPaused = false;
		menu.SetActive (false);
		Time.timeScale = 1f;
	}

	public void ReturnToMain() {
		SceneManager.LoadScene (mainMenuScene);
		ResumeGame ();
	}

	public void QuitGame() {
		Application.Quit ();
	}

	public void SetVolume(float volume) {
		PlayerPrefs.SetFloat ("Volume", volume);
	}
}
