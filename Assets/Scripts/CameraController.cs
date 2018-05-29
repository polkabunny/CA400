using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject followTarget;
	public float moveSpeed;
	public BoxCollider2D bounds;

	private Vector3 minBounds, maxBounds, targetPosition;
	private Camera cam;
	private float halfHeight, halfWidth;
	private static bool cameraExists;

	// Use this for initialization
	void Start () {
		minBounds = bounds.bounds.min;
		maxBounds = bounds.bounds.max;

		cam = GetComponent<Camera> ();
		halfHeight = cam.orthographicSize;
		halfWidth = halfHeight * Screen.width / Screen.height;

		if (!cameraExists) {
			cameraExists = true;
			DontDestroyOnLoad (transform.gameObject);
		} else {
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		var targetVector = followTarget.transform.position;
		targetPosition = new Vector3 (targetVector.x, targetVector.y, transform.position.z);
		transform.position = Vector3.Lerp (transform.position, targetPosition, moveSpeed);

		float clampedX = Mathf.Clamp (transform.position.x, (minBounds.x + halfWidth), (maxBounds.x - halfWidth));
		float clampedY = Mathf.Clamp(transform.position.y, (minBounds.y + halfHeight), (maxBounds.y - halfHeight));
		transform.position = new Vector3 (clampedX, clampedY, transform.position.z);
	}

	public void SetBounds(BoxCollider2D box) {
		bounds = box;

		minBounds = bounds.bounds.min;
		maxBounds = bounds.bounds.max;
	}
}
