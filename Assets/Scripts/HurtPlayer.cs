using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {

	public int damageDone;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D otherObj) {
		if (otherObj.gameObject.name == "Player") {
			otherObj.gameObject.GetComponent<PlayerHealthController> ().HurtPlayer(damageDone);
		}
	}
}
