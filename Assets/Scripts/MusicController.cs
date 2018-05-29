﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {

	public static bool mcExists;
	public AudioSource[] tracks;
	public int currentTrack;
	public bool musicCanPlay;

	// Use this for initialization
	void Start () {
		if (!mcExists) {
			mcExists = true;
			DontDestroyOnLoad (transform.gameObject);
		} else {
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (musicCanPlay) {
			if (!tracks [currentTrack].isPlaying) {
				tracks [currentTrack].Play ();
			}
		} else {
			tracks [currentTrack].Stop ();
		}
	}

	public void SwitchTrack(int trackNum) {
		tracks [currentTrack].Stop ();
		currentTrack = trackNum;
		tracks [currentTrack].Play ();
	}
}
