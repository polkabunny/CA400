using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

	public int maxHealth, currentHealth;
	public string enemyName;

	private QuestManager qManager;
	public DropCoin coinDrop;
	//public bool dead;

	// Use this for initialization
	void Start () {
		SetMaxHealth();
		qManager = FindObjectOfType<QuestManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (currentHealth <= 0) {
			KillEnemy ();
		}
	}

	public void HurtEnemy(int damage) {
		currentHealth -= damage;
	}

	public void SetMaxHealth() {
		currentHealth = maxHealth;
	}

	public void KillEnemy() {
		qManager.enemyKilled = enemyName;
		coinDrop.SetCoinActive();
		Destroy (gameObject);
	}
}
