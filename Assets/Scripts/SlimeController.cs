using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeController : MonoBehaviour {

	public float moveSpeed, timeBetweenMoves, timeToMove, waitToReload;
	public bool reloading;

	private Rigidbody2D myRigidbody;
	private bool moving;
	private float betweenMoveCounter, toMoveCounter;
	private Vector3 moveDirection;
	private GameObject player;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();
		SetBetweenMove();
		SetToMove();
	}
	
	// Update is called once per frame
	void Update () {
		if (moving) {
			toMoveCounter -= Time.deltaTime;
			myRigidbody.velocity = moveDirection;
			if (toMoveCounter < 0f) {
				moving = !moving;
				SetBetweenMove();
			}
		} else {
			betweenMoveCounter -= Time.deltaTime;
			myRigidbody.velocity = Vector2.zero;
			if (betweenMoveCounter < 0f) {
				moving = !moving;
				SetToMove();
				// Choose a random direction
				moveDirection = new Vector3 (Random.Range (-1f, 1f) * moveSpeed, Random.Range (-1f, 1f) * moveSpeed);
			}
		}

		if (reloading) {
			waitToReload -= Time.deltaTime;
			if (waitToReload < 0) {
				reloading = false;
				SceneManager.LoadSceneAsync (SceneManager.GetActiveScene().buildIndex);
				player.SetActive (true);
			}
		}
	}

	void SetToMove() {
		toMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);
	}

	void SetBetweenMove() {
		betweenMoveCounter = Random.Range(timeBetweenMoves * 0.75f, timeBetweenMoves * 1.25f);
	}
}
