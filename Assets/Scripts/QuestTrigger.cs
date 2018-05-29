using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour {

	public int questNum;
	public bool startQuest, endQuest;

	private QuestManager manager;


	// Use this for initialization
	void Start () {
		manager = FindObjectOfType<QuestManager>();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.name == "Player") {
			if(!manager.completedQuests[questNum]) {
				if(startQuest && !manager.quests[questNum].gameObject.activeSelf) {
					manager.quests[questNum].gameObject.SetActive(true);
					manager.quests[questNum].StartQuest();
				} else if(endQuest && manager.quests[questNum].gameObject.activeSelf) {
					manager.quests[questNum].EndQuest();
				}
			}
		} 
	}
}
