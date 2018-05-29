using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour {

	public float defaultVolume;

	private AudioSource audio;
	private float volume;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetAudioLevel(float volumeLevel) {
		if (audio == null) {
			audio = GetComponent<AudioSource> ();
		}

		//volume = defaultVolume * volumeLevel;
		audio.volume = volumeLevel;
	}
}
