using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour {

	public float moveSpeed, walkTime, waitTime;
	public bool walking, canMove;
	public Collider2D walkZone;

	private Rigidbody2D myRigidBody;
	private float walkCounter, waitCounter;
	private int walkDirection;
	private Vector2 minWalkPoint, maxWalkPoint;
	private bool hasWalkZone;
	private DialogueManager dManager;

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D> ();
		dManager = FindObjectOfType<DialogueManager> ();
		waitCounter = waitTime;
		canMove = true;

		ChooseDirection ();

		if (walkZone != null) {
			minWalkPoint = walkZone.bounds.min;
			maxWalkPoint = walkZone.bounds.max;
			hasWalkZone = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!dManager.active) {
			canMove = true;
		}

		if (!canMove) {
			myRigidBody.velocity = Vector2.zero;
			return;
		}

		if (walking) {
			walkCounter -= Time.deltaTime;

			switch (walkDirection) {
				case 0:
					myRigidBody.velocity = new Vector2 (0, moveSpeed);
					if (hasWalkZone && (transform.position.y >= maxWalkPoint.y)) {
						walking = false;
						waitCounter = waitTime;
					}
					break;
				case 1:
					myRigidBody.velocity = new Vector2 (moveSpeed, 0);
					if (hasWalkZone && (transform.position.x >= maxWalkPoint.x)) {
						walking = false;
						waitCounter = waitTime;	
					}
					break;
				case 2:
					myRigidBody.velocity = new Vector2 (0, -moveSpeed);
					if (hasWalkZone && (transform.position.y <= maxWalkPoint.y)) {
						walking = false;
						waitCounter = waitTime;	
					}
					break;

				case 3:
					myRigidBody.velocity = new Vector2 (-moveSpeed, 0);
					if (hasWalkZone && (transform.position.x <= maxWalkPoint.x)) {
						walking = false;
						waitCounter = waitTime;	
					}
					break;
			}

			if (walkCounter < 0) {
				walking = !walking;
				waitCounter = waitTime;	
			}

		} else {
			waitCounter -= Time.deltaTime;
			myRigidBody.velocity = Vector2.zero;
			if (waitCounter < 0) {
				ChooseDirection ();
			}
		}
	}

	public void ChooseDirection() {
		walkDirection = Random.Range (0, 4);
		walking = true;
		walkCounter = walkTime;
	}
}
