using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCoin : MonoBehaviour {

	public GameObject coin;
	public EnemyHealthManager enemy;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetCoinActive() {
		coin.SetActive (true);
	}
}
