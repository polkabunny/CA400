using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float attackTime, moveSpeed;
	public Vector2 lastMove;
	public GameObject weapon;
	public bool canMove;

	private Animator anim;
	private bool playerMoving, attacking;
	private Rigidbody2D myRigidBody;
	private static bool playerExists;
	private float attackCounter;
	private SFXManager sfxManager;

	// Use this for initialization
	void Start () {
		canMove = true;
		anim = GetComponent<Animator>();
		myRigidBody = GetComponent<Rigidbody2D>();
		sfxManager = FindObjectOfType<SFXManager> ();
		if (!playerExists) {
			playerExists = true;
			DontDestroyOnLoad (transform.gameObject);
		} else {
			Destroy (gameObject);
		}
	}

	// Update is called once per frame
	void Update () {
		CheckAndEnableSprite ();

		playerMoving = false;

		if (!canMove) {
			myRigidBody.velocity = Vector2.zero;
			return;
		}

		if (!attacking) {

			if (Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw ("Horizontal") < -0.5f) {
				myRigidBody.velocity = new Vector2 (Input.GetAxisRaw ("Horizontal") * moveSpeed, myRigidBody.velocity.y);
				playerMoving = true;
				lastMove = new Vector2 (Input.GetAxisRaw ("Horizontal"), 0f);
			}
			if (Input.GetAxisRaw ("Vertical") > 0.5f || Input.GetAxisRaw ("Vertical") < -0.5f) {
				myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x, Input.GetAxisRaw ("Vertical") * moveSpeed);
				playerMoving = true;
				lastMove = new Vector2 (0f, Input.GetAxisRaw ("Vertical"));
			}

			if (Input.GetAxisRaw ("Horizontal") < 0.5f && Input.GetAxisRaw ("Horizontal") > -0.5f) {
				myRigidBody.velocity = new Vector2 (0f, myRigidBody.velocity.y);
			}
			if (Input.GetAxisRaw ("Vertical") < 0.5f && Input.GetAxisRaw ("Vertical") > -0.5f) {
				myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x, 0f);
			}
		}

		if (Input.GetKeyDown (KeyCode.J)) {
			attackCounter = attackTime;
			attacking = true;
			myRigidBody.velocity = Vector2.zero;
			anim.SetBool ("Attack", true);

			sfxManager.attack.Play ();
		}

		if (attackCounter > 0) {
			attackCounter -= Time.deltaTime;
		}
		if (attackCounter <= 0) {
			attacking = false;
			anim.SetBool ("Attack", false);
		}


		anim.SetFloat ("MoveX", Input.GetAxisRaw ("Horizontal"));
		anim.SetFloat ("MoveY", Input.GetAxisRaw ("Vertical"));
		anim.SetBool ("PlayerMoving", playerMoving);
		anim.SetFloat ("LastMoveX", lastMove.x);
		anim.SetFloat ("LastMoveY", lastMove.y);
	}

	void CheckAndEnableSprite() {
		if(!gameObject.GetComponent<SpriteRenderer> ().enabled)
			gameObject.GetComponent<SpriteRenderer> ().enabled = true;
	}
}
