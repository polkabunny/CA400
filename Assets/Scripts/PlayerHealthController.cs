using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthController : MonoBehaviour {

	public int playerMaxHealth, playerCurrentHealth;
	public bool isDead;

	private PlayerController player;
	private SpriteRenderer playerSprite;
	private SFXManager sfxManager;
	private MoneyManager mManager;

	// Use this for initialization
	void Start () {
		SetMaxHealth();
		player = FindObjectOfType<PlayerController> ();
		playerSprite = player.GetComponent<SpriteRenderer> ();
		sfxManager = FindObjectOfType<SFXManager> ();
		mManager = FindObjectOfType<MoneyManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerCurrentHealth <= 0) {
			player.GetComponent<SpriteRenderer> ().enabled = false;
			sfxManager.dead.Play ();
			SetMaxHealth ();
			mManager.EmptyPockets ();
			SceneManager.LoadScene ("LoseScreen");
		}
	}

	public void HurtPlayer(int damage) {
		playerCurrentHealth -= damage;
		sfxManager.hurt.Play ();
	}

	public void SetMaxHealth() {
		playerCurrentHealth = playerMaxHealth;
	}
}
