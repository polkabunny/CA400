using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour {

	public AudioSource hurt, dead, attack;

	private static bool manExists;

	// Use this for initialization
	void Start () {
		if (!manExists) {
			manExists = true;
			DontDestroyOnLoad (transform.gameObject);
		} else {
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
