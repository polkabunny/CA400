using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour {

	public string dialogueText;
	public bool playerEntered;
	public string[] dialogueArray;

	private DialogueManager manager;

	// Use this for initialization
	void Start () {
		manager = FindObjectOfType<DialogueManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.E) && playerEntered) {
			if (!manager.active) {
				manager.dialogueArray = dialogueArray;
				manager.currentLine = 0;
				manager.ShowDialogue ();
			}
			if (GetComponentInParent<NPCMovement> () != null) {
				GetComponentInParent<NPCMovement> ().canMove = false;
			}
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.name == "Player") {
			playerEntered = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.name == "Player") {
			playerEntered = false;
		}
	}
}
