using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour {

	public int questNum;
	public string name;

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
			if(!manager.completedQuests[questNum] && manager.quests[questNum].gameObject.activeSelf) {
				manager.itemCollected = name;
				gameObject.SetActive(false);
			}
		}
	}
}
