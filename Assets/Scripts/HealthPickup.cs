using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour {

	public PlayerHealthController player;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerHealthController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.name == "Player") {
			if (Input.GetKeyDown (KeyCode.E)) {
				player.SetMaxHealth ();
			}
		}
	}
}
