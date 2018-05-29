using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public GameObject dialogueBox;
	public Text dialogue;
	public bool active;
	public string[] dialogueArray;
	public int currentLine;

	private PlayerController player;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!active) {
			dialogueBox.SetActive (false);
		} else if (active && Input.GetKeyDown(KeyCode.Space)) {
			if (currentLine >= dialogueArray.Length - 1) {
				dialogueBox.SetActive (false);
				active = false;
				currentLine = 0;
				player.canMove = true;
			} else {
				currentLine++;
			}
		}
		dialogue.text = dialogueArray [currentLine];
	}

	public void SetActive() {
		active = true;
		dialogueBox.SetActive (true);
		player.canMove = false;
	}

	public void ShowBox(string dialogueText) {
		SetActive ();
		dialogue.text = dialogueText;
	}

	public void ShowDialogue() {
		SetActive ();
	}
}
