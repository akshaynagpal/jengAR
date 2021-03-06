﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSwitch : MonoBehaviour {

	public bool enabled;

	public GameObject tower;
	public GameObject toy;
	public GameObject hereDot;

	private bool gameOverMode;
	public Vector3 gameOverStepper;
	public Vector3 gameOverScale;

	// Use this for initialization
	void Start () {
		gameOverMode = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameOverMode) {
			if (transform.localScale.magnitude > gameOverScale.magnitude) {
				transform.localScale -= gameOverStepper;
			}
		}
	}

	public void flipSwitch(bool isOn) {
		if (!isOn) {
			foreach (Transform child in tower.transform) {
				child.GetComponent<forkBlockCollission> ().gravityDisable (true);
				child.GetComponent<forkBlockCollission> ().interactionDisable (true);
			}
			toy.GetComponent<Collider> ().enabled = true;
			foreach (Transform item in toy.transform) {
				if (item.GetComponent<Collider> () != null) {
					item.GetComponent<Collider> ().enabled = true;
				}
			}
			hereDot.SetActive (true);
		} else {
			foreach (Transform child in tower.transform) {
				child.GetComponent<forkBlockCollission> ().gravityDisable (false);
				child.GetComponent<forkBlockCollission> ().interactionDisable (false);
			}
			toy.GetComponent<Collider> ().isTrigger = true;
			toy.GetComponent<Rigidbody> ().detectCollisions = false;
			toy.GetComponent<Rigidbody> ().isKinematic = true;
			foreach (Transform item in toy.transform) {
				if (item.GetComponent<Collider> () != null) {
					item.GetComponent<Collider> ().isTrigger = true;
				}
			}
			hereDot.SetActive (false);
		}
	}

	public void gameOverOps(bool enter) {
		gameOverMode = enter;
		toy.GetComponent<WorldController> ().gameOverOps (enter);
	}
}
