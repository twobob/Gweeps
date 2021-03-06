﻿using UnityEngine;
using System.Collections;


public class CameraController : MonoBehaviour {

	private GameObject player;
	private Vector3 offset;
	private GameObject boundary;
	private float min_X, max_X, min_Y, max_Y;

	// Use this for initialization
	void Start () {
		player = transform.parent.gameObject;
		boundary = GameObject.FindGameObjectWithTag ("Boundary");
		offset = transform.position - player.transform.position;
		min_X = boundary.transform.position.x - ((float)boundary.transform.localScale.x/2);
		max_X = boundary.transform.position.x + ((float)boundary.transform.localScale.x/2);
		min_Y = boundary.transform.position.y - ((float)boundary.transform.localScale.y/2);
		max_Y = boundary.transform.position.y + ((float)boundary.transform.localScale.y/2);
		float boundaryWidth = boundary.transform.localScale.x;
		if (boundaryWidth < 30) {
			GetComponent<CameraController> ().enabled = false;
		}

	}


	void LateUpdate () {
		transform.position = new Vector3(
			Mathf.Clamp(player.transform.position.x + offset.x, min_X + 14.4f, max_X - 14.4f),
			Mathf.Clamp(player.transform.position.y + offset.y, min_Y + 7.14f, max_Y - 7.14f),
			-10
		);

	}
}
