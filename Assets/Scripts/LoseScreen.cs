using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreen : MonoBehaviour {

	public float timer;
	public string startScene;
	public GameObject hud;

	private float countdown;

	// Use this for initialization
	void Start () {
		countdown = timer;
	}
	
	// Update is called once per frame
	void Update () {
		if (hud.activeSelf) {
			hud.SetActive (false);
		}
		countdown -= Time.deltaTime;
		if (countdown < 0) {
			hud.SetActive (true);
			SceneManager.LoadScene (startScene);
		}
	}
}
