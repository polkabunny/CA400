﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour {

	public Vector2 startDir;

	private PlayerController player;
	private CameraController camera;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
		player.transform.position = transform.position;
		camera = FindObjectOfType<CameraController> ();
		camera.transform.position = new Vector3(transform.position.x, transform.position.y, camera.transform.position.z);
		player.lastMove = startDir;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
