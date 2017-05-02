﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSwitch : MonoBehaviour {

	public bool enabled;

	public GameObject tower;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void flipSwitch(bool isOn) {
		if (!isOn) {
			foreach (Transform child in tower.transform) {
				child.GetComponent<forkBlockCollission> ().gravityDisable (true);
				child.GetComponent<forkBlockCollission> ().interactionDisable (true);
			}
		} else {
			foreach (Transform child in tower.transform) {
				child.GetComponent<forkBlockCollission> ().gravityDisable (false);
				child.GetComponent<forkBlockCollission> ().interactionDisable (false);
			}
		}
	}
}