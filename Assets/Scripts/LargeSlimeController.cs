using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeSlimeController : MonoBehaviour {

	public float moveSpeed;
	public bool playerNear;
	public SlimeController blueSlime;

	private PlayerController player;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerNear) {
			float steps = moveSpeed * Time.deltaTime;
			blueSlime.transform.position = Vector3.MoveTowards (blueSlime.transform.position, player.transform.position, steps);
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.name == "Player") {
			playerNear = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.name == "Player") {
			playerNear = false;
		}
	}
}
