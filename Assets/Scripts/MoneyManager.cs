using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour {

	public Text coinText;
	public int count;

	// Use this for initialization
	void Start () {
		count = 0;

		UpdateDisplayText();
	}
	
	// Update is called once per frame
	void Update () {
		if (count >= 175) {
			SceneManager.LoadScene ("WinScreen");
		}
	}

	public void UpdateDisplayText() {
		coinText.text = "Gold: " + count;
	}

	public void AddCoin(int gold) {
		count += gold;
		UpdateDisplayText ();
	}

	public void RemoveCoin(int gold) {
		count -= gold;
		UpdateDisplayText ();
	}

	public void EmptyPockets() {
		count = 0;
	}
}
