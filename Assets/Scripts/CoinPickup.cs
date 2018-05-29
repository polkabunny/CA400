using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour {

	public int value;
	private MoneyManager manager;

	// Use this for initialization
	void Start () {
		manager = FindObjectOfType<MoneyManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.name == "Player") {
			manager.AddCoin (value);
			Destroy (gameObject);
		}
	}
}
