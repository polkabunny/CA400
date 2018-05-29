using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public PlayerHealthController health;
	public Slider bar;
	public Text status;

	private static bool uiExists;

	// Use this for initialization
	void Start () {
		if (!uiExists) {
			uiExists = true;
			DontDestroyOnLoad (transform.gameObject);
		} else {
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		bar.maxValue = health.playerMaxHealth;
		bar.value = health.playerCurrentHealth;
		status.text = "Health: " + bar.value + "/" + bar.maxValue;
	}
}
