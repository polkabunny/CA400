using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingNPCController : MonoBehaviour {

	public float turnTime;
	public bool canMove;

	private int direction;
	private float turnCounter;
	private DialogueManager dManager;
	private Animator anim;

	// Use this for initialization
	void Start () {
		ChooseDirection ();
		dManager = FindObjectOfType<DialogueManager> ();
		anim = GetComponent<Animator>();
		canMove = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (canMove) {
			turnCounter -= Time.deltaTime;

			anim.SetInteger ("direction", direction);
		}
	}

	public void ChooseDirection() {
		direction = Random.Range (0, 4);
	}
}
