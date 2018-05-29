using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

	public QuestObject[] quests;
	public bool[] completedQuests;
	public DialogueManager dManager;
	public string itemCollected;
	public string enemyKilled;

	// Use this for initialization
	void Start () {
		completedQuests = new bool[quests.Length];
	}

	// Update is called once per frame
	void Update () {

	}

	public void ShowQuestText(string questText) {
		dManager.dialogueArray = new string[1];
		dManager.dialogueArray[0] = questText;
		dManager.currentLine = 0;
		dManager.ShowDialogue ();
	}
}
