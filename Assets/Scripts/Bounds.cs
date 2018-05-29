using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour {

	private BoxCollider2D bounds;
	private CameraController cam;

	// Use this for initialization
	void Start () {
		bounds = GetComponent<BoxCollider2D> ();
		cam = FindObjectOfType<CameraController> ();
		cam.SetBounds (bounds);
	}
}
