using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour {

	public int questNum, enemiesToKill;
	public QuestManager manager;
	public string startText, endText, targetItem;//, targetEnemy;
	public bool isItemQuest, isEnemyQuest;
	public string[] targetEnemies;

	private int enemyKills;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (isItemQuest) {
			if (manager.itemCollected == targetItem) {
				manager.itemCollected = null;
				EndQuest ();
			}
		} else if (isEnemyQuest) {
			for(int i = 0; i < targetEnemies.Length; i++) {
				if (targetEnemies [i] == manager.enemyKilled) {
					manager.enemyKilled = null;
					enemyKills++;
					Debug.Log (enemyKills);
				}
			}
			if (enemyKills >= enemiesToKill)
				EndQuest ();
		}
	}

	public void StartQuest() {
		manager.ShowQuestText (startText);
	}

	public void EndQuest() {
		manager.ShowQuestText (endText);
		manager.completedQuests [questNum] = true;
		gameObject.SetActive (false);
	}
}
