using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitcher : MonoBehaviour {

	public int trackNum;
	public bool switchOnStart;

	private MusicController controller;

	// Use this for initialization
	void Start () {
		controller = FindObjectOfType<MusicController> ();

		if (switchOnStart) {
			controller.SwitchTrack (trackNum);
			gameObject.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.name == "Player") {
			controller.SwitchTrack (trackNum);
			gameObject.SetActive (false);
		}
	}
}
