using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeManager : MonoBehaviour {

	public VolumeController[] vcObjects;
	public float currentVolume;
	public float maxLevel = 1.0f;

	private float prefVolume;

	// Use this for initialization
	void Start () {
		vcObjects = FindObjectsOfType<VolumeController> ();
		prefVolume = PlayerPrefs.GetFloat ("Volume");
		if (prefVolume > maxLevel)
			prefVolume = maxLevel;

		for (int i = 0; i < vcObjects.Length; i++) {
			vcObjects [i].SetAudioLevel (prefVolume);
		}
		currentVolume = prefVolume;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ChangeVolume() {
		//var prefVolume = PlayerPrefs.GetFloat ("Volume");
		//if (prefVolume != currentVolume) {
			if (currentVolume > maxLevel) {
				currentVolume = maxLevel;
			}
			for (int i = 0; i < vcObjects.Length; i++) {
				vcObjects [i].SetAudioLevel (currentVolume);
			}
			PlayerPrefs.SetFloat ("Volume", currentVolume);
		}
	//}
}
