﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour {

	public Slider slider;

	// Use this for initialization
	void Start () {
		slider.value = PlayerPrefs.GetFloat ("Volume");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetVolume(float volume) {
		PlayerPrefs.SetFloat ("Volume", volume);
	}
}
